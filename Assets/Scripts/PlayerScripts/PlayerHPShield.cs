using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPShield : MonoBehaviour
{
    [field: SerializeField] public int MaxPlayerHP { get; private set; }
    [field: SerializeField] public int PlayerHP { get; private set; }
    [field: SerializeField] public int MaxPlayerShield { get; private set; }
    [field: SerializeField] public int PlayerShield { get; private set; }
    [SerializeField] int _shieldPower;
    [SerializeField] PlayerDamageGUI _playerDamageGUI;

    void Start()
    {
        _playerDamageGUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<PlayerDamageGUI>();  
    }

    void Update()
    {
        DiePlayer();
    }

    public void MinusPlayerHpShiled(int _damageCount)
    {
        _playerDamageGUI.PlayPlayerDamageAnimation();
        if (PlayerShield > 0)
        {
            PlayerShield -= _damageCount / _shieldPower;
        }
        else if (PlayerShield <= 0)
        {
            PlayerHP -= _damageCount;
        }
    }

    public void PlayerHealing()
    {
        PlayerHP = MaxPlayerHP;
        PlayerShield = MaxPlayerShield;
    }

    void DiePlayer()
    {
        if (PlayerHP <= 0)
        {
            GameObject.FindGameObjectWithTag("GameUI").GetComponent<DieMenuScript>().OnDieMenu();
        }
    }
}
