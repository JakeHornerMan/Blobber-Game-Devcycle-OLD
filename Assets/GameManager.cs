using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
