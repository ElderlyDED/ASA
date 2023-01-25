using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    [SerializeField] SpawnAmmoCrate _spawnAmmoScript;
    [SerializeField] SpawnWeaponStation _spawnWeaponScript;
    [field: SerializeField] public int Time { get; private set; }
    [field: SerializeField] public string TimerText { get; private set; }
    [SerializeField] int _nextTimeSpawnAmmo;
    [SerializeField] int _nextSpawnWeaponStation;
    [SerializeField] int _min;
    [SerializeField] int _minSec;
    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        OnSpawningWeaponStation();
        OnSpawningAmmoCrate();
        SetMinute();
        SetTimerText();
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Time += 1;
            _minSec += 1;
        }
    }

    void OnSpawningAmmoCrate()
    {
        if (_nextTimeSpawnAmmo == Time)
        {
            _nextTimeSpawnAmmo += 60;
            _spawnAmmoScript.OnSpawnAmmoCrate();
        } 
    }

    void OnSpawningWeaponStation()
    {
        if (_nextSpawnWeaponStation == Time)
        {
            _nextSpawnWeaponStation += 180;
            _spawnWeaponScript.OnSpawnWeaponStation();
        }
    }

    void SetMinute()
    {
        if (_minSec == 60)
        {
            _minSec = 0;
            _min += 1;
        }
    }

    void SetTimerText()
    {
        if (_minSec < 10)
        {
            TimerText = _min.ToString() + " : " + "0" + _minSec.ToString();
        }
        else
        {
            TimerText = _min.ToString() + " : " + _minSec.ToString();
        }
        
    }
}
