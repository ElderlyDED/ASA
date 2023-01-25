using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenuScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _enemyKillsText;
    [SerializeField] GameObject _dieMenuObj;
    [SerializeField] FirstPersonController _firstPersonController;
    void Start()
    {
        _firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }
    public void OnDieMenu()
    {
        _firstPersonController.cameraCanMove = false;
        _firstPersonController.lockCursor = false;
        _dieMenuObj.SetActive(true);
        _timeText.text = GameObject.FindGameObjectWithTag("WorldTimer").GetComponent<WorldTimer>().TimerText;
        _enemyKillsText.text = GameObject.FindGameObjectWithTag("GameUI").GetComponent<EnemyDieScore>()._enemyDieCount.ToString();
        Time.timeScale = 0f;
    }

    public void MainMenuBtnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
