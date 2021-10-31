using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        HPScript.hpScore = 5;
        Score.scoreValue = 0;
        StarScript.starPoints = 0;
        //Can use this function everytime you wanna go to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);   
    }
    public void Next()
    {
        HPScript.hpScore = 5;
        Score.scoreValue = 0;
        StarScript.starPoints = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LevelThree()
    {
        HPScript.hpScore = 5;
        Score.scoreValue = 0;
        StarScript.starPoints = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Back()
    {
        HPScript.hpScore = 5;
        Score.scoreValue = 0;
        StarScript.starPoints = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Main()
    {
        HPScript.hpScore = 5;
        Score.scoreValue = 0;
        StarScript.starPoints = 0;
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
}
