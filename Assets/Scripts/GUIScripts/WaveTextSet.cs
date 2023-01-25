using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveTextSet : MonoBehaviour
{
    [SerializeField] EnemySpawner _enemySpawnerScript;
    [SerializeField] TextMeshProUGUI _waveText;
    void Start()
    {
        _enemySpawnerScript = GameObject.FindGameObjectWithTag("WorldTimer").GetComponent<EnemySpawner>();
    }
    void Update()
    {
        _waveText.text = "WAVE: " + _enemySpawnerScript.Wave.ToString();
    }
}
