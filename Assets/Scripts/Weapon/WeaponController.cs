using GoonRaccoon.Utils.DebugUtils;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour, IEquippedItem
{
    [Header("Weapon Dependencies")]
    [SerializeField] private Camera _playerFPSCamera;
    [SerializeField] private VHS.CameraController _cameraController;

    [SerializeField] private WeaponEffects _weaponEffects;

    public Transform opticsObject;
    public Transform equippedHolder;

    private float _fireRate;
    private float _baseDamage;
    private float _bulletsPerMagazine;
    private float _reloadTime;
    private float _maxRange;

    [Header("Aiming Down Sights")]
    [SerializeField] private float _adsSpeed;
    [SerializeField] private float _opticsForwardOffset;

    private float lastShotTime = 0f;

    private bool isTriggerPulled = false;
    private bool isReloading = false;
    private bool isAimingDownSights = false;

    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;

    [Header("Weapon Data")]
    [SerializeField] private Weapon _weaponData;

    public ItemBase itemData
    {
        get { return _weaponData; }
        set { _weaponData = (Weapon)value; }
    }

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
        InitWeapon();

        _playerFPSCamera = Camera.main;
        _weaponEffects = GetComponent<WeaponEffects>();

        _cameraController = GameObject.Find("Camera_Holder").GetComponent<VHS.CameraController>();
        equippedHolder = GameObject.Find("Camera_Pivot").transform;
    }    

    public void Update()
    {
        if (isTriggerPulled && !isReloading)
        {
            ApplyFireMode();
            FireWeapon();
        }
        PositionWeaponToADS();
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

                _cameraController.AddRecoil(_weaponData.recoilSpread_Vertical, _weaponData.recoilSpread_Horizontal);
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

    private void PositionWeaponToADS()
    {
        Vector3 targetPosition = transform.position;

        if (isAimingDownSights)
        {
            targetPosition = _playerFPSCamera.transform.position + (transform.position - opticsObject.position) + equippedHolder.transform.forward * _opticsForwardOffset; //equippedHolder.transform.position + (equippedHolder.position - opticsObject.position) + equippedHolder.transform.forward * _opticsForwardOffset;

            transform.rotation = _playerFPSCamera.transform.rotation;
            transform.position = targetPosition;
        }  
        else
        {
            transform.position = _defaultPosition;
            transform.rotation = _defaultRotation;
        }
        
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

        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation;
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
        // Toggle mode
        isAimingDownSights = !isAimingDownSights;
    }

    public void StopSecondaryTriggerAction()
    {
        ;
    }

    public void ReloadAction()
    {
        StartCoroutine(ReloadWeaponSequence());
    }

    #endregion
}
