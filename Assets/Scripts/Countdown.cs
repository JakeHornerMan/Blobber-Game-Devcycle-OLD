using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeStart ;
    public Text Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart >= 0)
        {
            timeStart -= Time.deltaTime;
        }
        else{
            FindObjectOfType<GameManager>().GameOver();
        }
        Timer.text = Mathf.Round(timeStart).ToString();
    }

    /*void FixedUpdate()
    {
        if (timeStart == 0) {
            FindObjectOfType<GameManager>().GameOver();
        }
    }*/
}
