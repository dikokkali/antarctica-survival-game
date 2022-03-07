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
    [SerializeField] private VHS.CameraController _cameraController;

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

    public FireMode selectedFireMode = FireMode.FullAuto;

    private void Awake()
    {        
        _playerFPSCamera = Camera.main;
        _weaponEffects = GetComponent<WeaponEffects>();

        // Input
        _playerInputManager = GameObject.Find("InputManager").GetComponent<PlayerInputManager>();
        _cameraController = GameObject.Find("Camera_Holder").GetComponent<VHS.CameraController>();

        fpsContextData = _playerInputManager.fpsInputContext;

        fireAction = fpsContextData.FPSControls.UseEquippedFireWeapon;
        reloadAction = fpsContextData.FPSControls.Reload;
       
        InitWeapon();
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
                _cameraController.AddRecoil();               

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

    public void ReloadAction()
    {
        StartCoroutine(ReloadWeaponSequence());
    }

    private IEnumerator ReloadWeaponSequence()
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

    public void StartPrimaryTriggerAction()
    {
        isTriggerPulled = true;
    }

    public void StopPrimaryTriggerAction()
    {
        isTriggerPulled = false;
    }

    public void StartSecondaryTriggerAction()
    {
        throw new System.NotImplementedException();
    }

    public void StopSecondaryTriggerAction()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
