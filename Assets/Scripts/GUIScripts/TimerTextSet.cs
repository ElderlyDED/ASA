using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerTextSet : MonoBehaviour
{
    [SerializeField] WorldTimer _timerScript;
    [SerializeField] TextMeshProUGUI _timerText;
    void Start()
    {
        _timerScript = GameObject.FindGameObjectWithTag("WorldTimer").GetComponent<WorldTimer>();
    }
    void Update()
    {
        _timerText.text = _timerScript.TimerText;
    }
}
