using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _weaponAudioSource;
    [SerializeField] AudioClip _weaponShotSound;
    [SerializeField] AudioClip _weaponReloadSound;
    [SerializeField] AudioClip _weaponChargeredSound;
    void Start()
    {
        _weaponAudioSource = GetComponent<AudioSource>();
    }

    public void PlayShotSound()
    {
        if (gameObject.activeSelf == true)
        {
            _weaponAudioSource.Stop();
            _weaponAudioSource.pitch = Random.Range(0.9f, 1.1f);
            _weaponAudioSource.clip = _weaponShotSound;
            _weaponAudioSource.Play();
        }
        else
        {
            return;
        }
    }

    public void PlayReloadSound()
    {
        if (gameObject.activeSelf == true)
        {
            _weaponAudioSource.Stop();
            _weaponAudioSource.clip = _weaponReloadSound;
            _weaponAudioSource.pitch = Random.Range(0.9f, 1.1f);
            _weaponAudioSource.Play();
        }
        else
        {
            return;
        }
    }

    public void PlayPowerUpSound()
    {
        if (_weaponChargeredSound == null)
        {
            return;
        }
        else
        {
            if (_weaponAudioSource.isPlaying == true)
            {
                return;
            }
            else
            {
                _weaponAudioSource.clip = _weaponChargeredSound;
                _weaponAudioSource.pitch = Random.Range(0.9f, 1.1f);
                _weaponAudioSource.Play();
            }
        } 
    }

    public void OffPowerUpSound()
    {
        _weaponAudioSource.Stop();
    }
}
