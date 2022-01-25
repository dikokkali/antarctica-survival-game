using GoonRaccoon.Utils.DebugUtils;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
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
    private ParticleSystem _muzzleFlashParticleSystem;
    private WeaponState weaponState;

    // Input actions
    InputAction fireAction;    

    [Header("Configurable Properties")]
    public float muzzleFlashDuration;

    public enum WeaponState
    {
        Weapon_Idle,
        Weapon_Firing,
        Weapon_Reloading
    }

    private void Awake()
    {
        lastShotTime = Time.time;
        weaponState = WeaponState.Weapon_Idle;

        _muzzleFlashParticleSystem = _muzzleFlash.GetComponent<ParticleSystem>();
        //_playerFPSCamera = GetComponentInParent<Camera>();

        // Initialize weapon data refs
        _fireRate = _weaponData.fireRate;
        _baseDamage = _weaponData.baseDamage;
        _bulletsPerMagazine = _weaponData.bulletsPerMagazine;
        _reloadTime = _weaponData.reloadTime;
        _maxRange = _weaponData.maxRange;
    }

    private void Update()
    {
        Debug.DrawRay(_playerFPSCamera.transform.position, _playerFPSCamera.transform.forward * 100f, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        if (Time.time - lastShotTime >= 1 / _fireRate)
        {
            lastShotTime = Time.time;

            StartCoroutine(nameof(ActivateWeaponEffects));

            Ray bulletRay = new Ray(_playerFPSCamera.transform.position, _playerFPSCamera.transform.forward);
            RaycastHit bulletHit;

            if (Physics.Raycast(bulletRay, out bulletHit, _maxRange))
            {
                Vector3 impactPoint = bulletHit.point;

                GameObject impact = Instantiate(_bulletImpact, impactPoint, Quaternion.LookRotation(bulletHit.normal));
                Destroy(impact, 2f);
            }
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

}
