using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject player;
    
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
    void OnCollisionEnter2D(Collision2D wall)
    {
        if (wall.gameObject.tag == "Wall")
        {
            //PlayerMove.wallBounce();
            player.GetComponent<Player_Move>().Slide = true;
            player.GetComponent<Player_Move>().wallBounce();
        }
        else {
            player.GetComponent<Player_Move>().Slide = false;
        }
    }
}
