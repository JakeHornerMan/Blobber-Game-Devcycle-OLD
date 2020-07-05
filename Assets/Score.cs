using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float scoreAmount;
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0000000000;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " +  scoreAmount;
    }
}
