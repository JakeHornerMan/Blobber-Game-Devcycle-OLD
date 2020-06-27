using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBlue : MonoBehaviour
{
    private IEnumerator coroutine;
    private int blueNum = 9;
    [SerializeField]
    private GameObject bluePrefab;
    // Start is called before the first frame update

    public void Update() {
        if (blueNum < 10) {
            spawnBlue();
        }
    }
    public void spawnBlue(){
        blueNum++;
        coroutine = WaitAndCreate(5f);
        StartCoroutine(coroutine);
    }
 
    IEnumerator WaitAndCreate(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        GameObject b = Instantiate(bluePrefab) as GameObject;
        b.transform.position = new Vector3(-39.4f, -5.98f, 0f);
    }
}