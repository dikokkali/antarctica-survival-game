using GoonRaccoon.Utils.DebugUtils;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private PlayerInputManager _playerInputManager;

    [SerializeField] public Weapon _weaponData;
    [SerializeField] private GameObject _playerFPSCamera;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private GameObject _bulletImpact;

    private float _fireRate;
    private float _baseDamage;
    private float _bulletsPerMagazine;
    private float _reloadTime;
    private float _maxRange;

    private float lastShotTime = 0f;
    private bool canFire = false;
    private bool isReloading = false;

    private ParticleSystem _muzzleFlashParticleSystem;

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
    public float muzzleFlashDuration;

    private void Awake()
    {
        // Input
        fpsContextData = _playerInputManager.fpsInputContext;

        fireAction = fpsContextData.FPSControls.UseEquippedFireWeapon;
        reloadAction = fpsContextData.FPSControls.Reload;

        _muzzleFlashParticleSystem = _muzzleFlash.GetComponent<ParticleSystem>();

        InitWeapon();
    }

    private void OnEnable()
    {     
        fireAction.performed += e => canFire = true;
        fireAction.canceled += e => canFire = false;

        reloadAction.performed += e => StartCoroutine(ReloadWeapon());
    }

    private void OnDisable()
    {
        fireAction.performed -= e => canFire = true;
        fireAction.canceled -= e => canFire = false;

        reloadAction.performed -= e => StartCoroutine(ReloadWeapon());
    }

    public void Update()
    {
        if (canFire && !isReloading)
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

                StartCoroutine(ActivateWeaponEffects());

                Ray bulletRay = new Ray(_playerFPSCamera.transform.position, _playerFPSCamera.transform.forward);
                RaycastHit bulletHit;

                if (Physics.Raycast(bulletRay, out bulletHit, _maxRange))
                {
                    Vector3 impactPoint = bulletHit.point;

                    GameObject impact = Instantiate(_bulletImpact, impactPoint, Quaternion.LookRotation(bulletHit.normal));
                    Destroy(impact, 2f);

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
            canFire = false;
        }
        else if (selectedFireMode == FireMode.FullAuto)
        {
            canFire = true;
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

    private IEnumerator ActivateWeaponEffects()
    {
        _muzzleFlash.SetActive(true);
        _muzzleFlashParticleSystem.Play();

        yield return new WaitForSeconds(muzzleFlashDuration);

        _muzzleFlashParticleSystem.Stop();
        _muzzleFlash.SetActive(false);
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
}
