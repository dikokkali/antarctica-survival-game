using GoonRaccoon.Utils.DebugUtils;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour, IEquippedItem
{
    [SerializeField] private PlayerInputManager _playerInputManager;    

    [SerializeField] private Camera _playerFPSCamera;

    [SerializeField] private WeaponEffects _weaponEffects;

    private float _fireRate;
    private float _baseDamage;
    private float _bulletsPerMagazine;
    private float _reloadTime;
    private float _maxRange;

    private float lastShotTime = 0f;
    private bool isTriggerPulled = false;
    private bool isReloading = false;

    [SerializeField] private Weapon _weaponData;

    public ItemBase itemData
    {
        get { return _weaponData; }
        set { _weaponData = (Weapon)value; }
    }

    // Input actions
    InputContextData_FPS fpsContextData;
    InputAction fireAction;
    InputAction reloadAction;

    [Header("Debug Info")]
    [ReadOnly] public float currentAmmo;

    public enum FireMode
    {
        SemiAuto,
        FullAuto
    }

    public FireMode selectedFireMode;

    private void Awake()
    {        
        _playerFPSCamera = Camera.main;
        _weaponEffects = GetComponent<WeaponEffects>();

        // Input
        _playerInputManager = GameObject.Find("InputManager").GetComponent<PlayerInputManager>();
        fpsContextData = _playerInputManager.fpsInputContext;

        fireAction = fpsContextData.FPSControls.UseEquippedFireWeapon;
        reloadAction = fpsContextData.FPSControls.Reload;
       
        InitWeapon();
    }

    private void OnEnable()
    {     
        fireAction.performed += StartPrimaryTrigger;
        fireAction.canceled += StopPrimaryTrigger;

        reloadAction.performed += e => StartCoroutine(ReloadWeapon());
    }

    private void OnDisable()
    {
        fireAction.performed -= StartPrimaryTrigger;
        fireAction.canceled -= StopPrimaryTrigger;

        reloadAction.performed -= e => StartCoroutine(ReloadWeapon());
    }

    public void Update()
    {
        if (isTriggerPulled && !isReloading)
        {
            ApplyFireMode();
            FireWeapon();
        }       
    }

    #region Weapon Methods

    private void FireWeapon()
    {
        if (currentAmmo >= 0)
        {           
            if (Time.time - lastShotTime >= 1 / _fireRate)
            {
                lastShotTime = Time.time;
                currentAmmo--;

                _weaponEffects.ActivateMuzzleFlash();

                Ray bulletRay = new Ray(_playerFPSCamera.transform.position, _playerFPSCamera.transform.forward);
                RaycastHit bulletHit;                

                if (Physics.Raycast(bulletRay, out bulletHit, _maxRange))
                {
                    _weaponEffects.CreateImpactEffect(bulletHit);

                    if (bulletHit.collider.gameObject.GetComponent<Rigidbody>() != null)
                    {
                        Vector3 forceDirection = bulletHit.point - _playerFPSCamera.transform.position;

                        bulletHit.collider.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * 100f, bulletHit.point);
                    }
                }
            }
        }
    }

    private void ApplyFireMode()
    {
        if (selectedFireMode == FireMode.SemiAuto)
        {
            isTriggerPulled = false;
        }
        else if (selectedFireMode == FireMode.FullAuto)
        {
            isTriggerPulled = true;
        }
    }

    private IEnumerator ReloadWeapon()
    {
        if (currentAmmo <= _bulletsPerMagazine)
        {
            Debug.Log("Reloading...");
            isReloading = true;

            yield return new WaitForSeconds(_reloadTime);

            currentAmmo = _bulletsPerMagazine;
            isReloading = false;
            Debug.Log("Reloaded.");
        }
    } 

    private void InitWeapon()
    {
        _fireRate = _weaponData.fireRate;
        _baseDamage = _weaponData.baseDamage;
        _bulletsPerMagazine = _weaponData.bulletsPerMagazine;
        _reloadTime = _weaponData.reloadTime;
        _maxRange = _weaponData.maxRange;

        selectedFireMode = FireMode.SemiAuto;
        lastShotTime = Time.time;

        currentAmmo = _bulletsPerMagazine;
    }

    #endregion

    #region Input Callbacks

    public void StartPrimaryTrigger(InputAction.CallbackContext ctx)
    {
        isTriggerPulled = true;
    }

    public void StopPrimaryTrigger(InputAction.CallbackContext ctx)
    {
        isTriggerPulled = false;
    }

    #endregion
}
