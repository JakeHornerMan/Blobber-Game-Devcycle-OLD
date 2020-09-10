using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private IEnumerator coroutine;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        Score.scoreAmount = 0;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Scoreboard()
    {
        //scoreboard script
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void titleStart()
    {
        FindObjectOfType<titleblue>().willRun = true;
        coroutine = WaitandPlay(3f);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitandPlay(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        Score.scoreAmount = 0;
        SceneManager.LoadScene("Game");
    }
}
