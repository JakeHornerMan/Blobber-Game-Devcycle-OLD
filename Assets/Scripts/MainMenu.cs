using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private IEnumerator coroutine;
    [SerializeField] public Scene Game;

    public void playGame() {
        FindObjectOfType<titleblue>().willRun = true;
        coroutine = WaitandLoad(2f);
        StartCoroutine(coroutine);
        //SceneManager.LoadScene("Game");
    }
    IEnumerator WaitandLoad(float _waitTime){
        yield return new WaitForSeconds(_waitTime);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
