using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Vector3 ShotPos;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ShotPos = player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(ShotPos, 15f);
    }
    private void Move(Vector3 target, float movementSpeed)
    {
        //Move
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }
}
