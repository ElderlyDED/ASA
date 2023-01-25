using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShieldBar : MonoBehaviour
{
    [SerializeField] Slider _hpSlider;
    [SerializeField] Slider _shieldSlider;
    [SerializeField] PlayerHPShield _playerHpScript;
    void Start()
    {
        _playerHpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHPShield>();
    }

    void Update()
    {
        SetHpShieldBar();
    }

    void SetHpShieldBar()
    {
        _hpSlider.maxValue = _playerHpScript.MaxPlayerHP;
        _hpSlider.value = _playerHpScript.PlayerHP;
        _shieldSlider.maxValue = _playerHpScript.MaxPlayerShield;
        _shieldSlider.value = _playerHpScript.PlayerShield;
    }
}
