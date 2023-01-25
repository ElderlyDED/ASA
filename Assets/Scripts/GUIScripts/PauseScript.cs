using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    [SerializeField] GameObject _pauseMenuObj;
    [SerializeField] PlayerInput _playerInputScript;
    [SerializeField] bool _pause;
    [SerializeField] FirstPersonController _firstPersonController;
    private void Start()
    {
        _playerInputScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }
    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().Pause += PauseSwitcher;
    }
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().Pause -= PauseSwitcher;
    }
    void PauseSwitcher()
    {
        if (_pause == false)
        {
            _firstPersonController.cameraCanMove = false;
            _firstPersonController.lockCursor = false;
            _pause = true;
            _pauseMenuObj.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (_pause == true)
        {
            _firstPersonController.cameraCanMove = true;
            _firstPersonController.lockCursor = true;
            _pause = false;
            _pauseMenuObj.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ResumeBtn()
    {
        _firstPersonController.cameraCanMove = true;
        _firstPersonController.lockCursor = true;
        _pause = false;
        _pauseMenuObj.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
