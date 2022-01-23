using GoonRaccoon.Utils.DebugUtils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Weapon _weaponData;
    [SerializeField] private Camera _playerFPSCamera;
    [SerializeField] private GameObject _muzzleFlash;

    private float _fireRate;
    private float _baseDamage;
    private float _bulletsPerMagazine;
    private float _reloadTime;
    private float _maxRange;

    private float lastShotTime = 0f;
    private WeaponState weaponState;

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

        if (Input.GetButton("Fire1"))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        if (Time.time - lastShotTime >= 1 / _fireRate)
        {
            StartCoroutine(nameof(ActivateWeaponEffects));

            Ray bulletRay = new Ray(_playerFPSCamera.transform.position, _playerFPSCamera.transform.forward);
            RaycastHit bulletHit;

            if (Physics.Raycast(bulletRay, out bulletHit, _maxRange))
            {
                
            }
        }
        else
        {
            StopCoroutine(nameof(ActivateWeaponEffects));
        }
    }

    private IEnumerator ActivateWeaponEffects()
    {
        _muzzleFlash.SetActive(true);

        yield return new WaitForSeconds(1 / _fireRate);

        _muzzleFlash.SetActive(false);

        //StopCoroutine(nameof(ActivateWeaponEffects));
    }

}
