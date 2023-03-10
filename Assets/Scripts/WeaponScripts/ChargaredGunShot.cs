using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargaredGunShot : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] public float chargaredTime;
    [SerializeField] public float maxCharge;
    [SerializeField] int _damage;
    [SerializeField] float _range;
    [SerializeField] FlashScript _flashScript;
    [SerializeField] ShotImpactScript _shotImpactScript;
    [SerializeField] float _delayShot;
    [SerializeField] bool _readyShot;
    PlayerInput _playerInputScript;
    [SerializeField] WeaponAnimator _weaponAnimatorScript;
    [SerializeField] WeaponAmmo _weaponAmmo;
    [SerializeField] WeaponSoundPlayer _weaponSoundPlayerScript;
    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _flashScript = gameObject.GetComponent<FlashScript>();
        _shotImpactScript = gameObject.GetComponent<ShotImpactScript>();
        _weaponAnimatorScript = gameObject.GetComponent<WeaponAnimator>();
        _weaponAmmo = gameObject.GetComponent<WeaponAmmo>();
        _weaponSoundPlayerScript = GetComponent<WeaponSoundPlayer>();
    }

    private void OnEnable()
    {
        _playerInputScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _playerInputScript.PressedFire += OnPressedFired;
        _playerInputScript.OffPressedFire += NotPressedFired;
    }

    private void OnDisable()
    {
        _playerInputScript.PressedFire -= OnPressedFired;
        _playerInputScript.OffPressedFire -= NotPressedFired;
    }

    void OnPressedFired()
    {
        if (_readyShot == true)
        {
            chargaredTime += 2 * Time.deltaTime;
            _weaponSoundPlayerScript.PlayPowerUpSound();
            if (chargaredTime > maxCharge)
            {
                NotPressedFired();
                chargaredTime = 0f;
                _readyShot = false;
                StartCoroutine(SwitcherReadyShot());
            }
        }  
    }

    void NotPressedFired()
    {
        if (_readyShot == true)
        {
            int _chargaredDamage = _damage + (_damage * (int)chargaredTime);
            chargaredTime = 0f;
            _weaponAmmo.ShotMinusAmmo();
            RaycastHit hit;
            _flashScript.PlayFlash();
            _weaponAnimatorScript.GunShotAnimation();
            _weaponSoundPlayerScript.OffPowerUpSound();
            _weaponSoundPlayerScript.PlayShotSound();
            if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
            {
                Debug.Log(hit.transform.name);
                EnemyHealth _eh = hit.transform.GetComponent<EnemyHealth>();
                if (_eh != null)
                {
                    gameObject.GetComponent<DamageEnemy>().GetDamage(_eh, _chargaredDamage);
                }
                _shotImpactScript.SpawnImpact(hit.point, Quaternion.LookRotation(hit.normal));
            }
            _readyShot = false;
            StartCoroutine(SwitcherReadyShot());
        }
    }

    IEnumerator SwitcherReadyShot()
    {
        yield return new WaitForSeconds(_delayShot);
        _readyShot = true;
    }
}
