using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider _masterSound;
    [SerializeField] Slider _weaponSound;
    [SerializeField] Slider _effectsSound;
    [SerializeField] Slider _enemySound;
    [SerializeField] Slider _worldSound;
    [SerializeField] Slider _musicSound;
    [SerializeField] AudioMixer _soundMixer;

    private void Start()
    {
        _masterSound.value = PlayerPrefs.GetFloat("MasterSound");
        _weaponSound.value = PlayerPrefs.GetFloat("WeaponSound");
        _effectsSound.value = PlayerPrefs.GetFloat("EffectSound");
        _enemySound.value = PlayerPrefs.GetFloat("EnemySound");
        _worldSound.value = PlayerPrefs.GetFloat("WorldSound");
        _musicSound.value = PlayerPrefs.GetFloat("MusicSound");
    }
    void Update()
    {
        PlayerPrefs.SetFloat("MasterSound", _masterSound.value);
        _soundMixer.SetFloat("Master", _masterSound.value);
        _masterSound.value = PlayerPrefs.GetFloat("MasterSound");

        PlayerPrefs.SetFloat("WeaponSound", _weaponSound.value);
        _soundMixer.SetFloat("Weapon", _weaponSound.value);
        _weaponSound.value = PlayerPrefs.GetFloat("WeaponSound");

        PlayerPrefs.SetFloat("EffectSound", _effectsSound.value);
        _soundMixer.SetFloat("Effect", _effectsSound.value);
        _effectsSound.value = PlayerPrefs.GetFloat("EffectSound");

        PlayerPrefs.SetFloat("EnemySound", _enemySound.value);
        _soundMixer.SetFloat("Enemy", _enemySound.value);
        _enemySound.value = PlayerPrefs.GetFloat("EnemySound");

        PlayerPrefs.SetFloat("WorldSound", _worldSound.value);
        _soundMixer.SetFloat("World", _worldSound.value);
        _worldSound.value = PlayerPrefs.GetFloat("WorldSound");

        PlayerPrefs.SetFloat("MusicSound", _musicSound.value);
        _soundMixer.SetFloat("Music", _musicSound.value);
        _musicSound.value = PlayerPrefs.GetFloat("MusicSound");
    }
}
