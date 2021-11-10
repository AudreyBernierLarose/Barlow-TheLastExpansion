using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        ResetInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);   
    }
    public void Next()
    {
        ResetInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LevelThree()
    {
        ResetInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Back()
    {
        ResetInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Main()
    {
        ResetInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    void ResetInfo()
    {
        HPScript.hpScore = 5;
        Score.scoreValue = 0;
        StarScript.starPoints = 0;
    }
}
