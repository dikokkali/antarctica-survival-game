using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffects : MonoBehaviour
{
    public float muzzleFlashDuration;

    public GameObject _muzzleFlash;
    public GameObject _bulletImpact;

    private ParticleSystem _muzzleFlashParticleSystem;

    private void Awake()
    {
        _muzzleFlashParticleSystem = _muzzleFlash.GetComponent<ParticleSystem>();
    }

    public void CreateImpactEffect(RaycastHit bulletHit)
    {
        GameObject impact = Instantiate(_bulletImpact, bulletHit.point, Quaternion.LookRotation(bulletHit.normal));

        Destroy(impact, 2f);
    }

    public void ActivateMuzzleFlash()
    {
        StartCoroutine(ActivateWeaponEffects());
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
