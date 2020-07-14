using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour  
{
    [SerializeField] public Scene Game;
    public void playGame() {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame() {
        Application.Quit();
    }
}
