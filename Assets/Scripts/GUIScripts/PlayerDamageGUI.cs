using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageGUI : MonoBehaviour
{
    [SerializeField] GameObject _damagePanel;
    public void PlayPlayerDamageAnimation()
    {
        _damagePanel.GetComponent<Animation>().Play();
    }
}
