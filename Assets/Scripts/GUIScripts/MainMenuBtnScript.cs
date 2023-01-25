using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtnScript : MonoBehaviour
{
    public void PlayBtnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }
}
