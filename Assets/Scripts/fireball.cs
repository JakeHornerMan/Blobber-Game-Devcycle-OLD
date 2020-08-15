using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Vector3 ShotPos;
    Vector3 position;
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
        position = transform.position;
        if (position == ShotPos) {
            Destroy(gameObject);
        }
    }
    private void Move(Vector3 target, float movementSpeed)
    {
        //Move
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }
}
