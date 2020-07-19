using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    public float speed;
    private int zigzag;
    public Transform wallDetection;
    private bool movingRight;
    private float chance;
    [SerializeField] private LayerMask platformLayerMask;
    private IEnumerator coroutine;
    
    void Start()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        chance = Random.Range(0f, 2f);

        if (chance <= 1)
        {
            movingRight = true;
            zigzag = 2;
        }
        else if (chance >= 1) {
            movingRight = false;
            zigzag = 1;
        }
            
    }

    void FixedUpdate()
    {
        Movement();
        yellowWallHit();
    }
    public void Movement() {
        if (movingRight == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (movingRight == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
        
        ZigZag();
        if (zigzag == 1)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (zigzag == 2)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        ZigZag();
    }
    public void ZigZag() {
        if (transform.position.y <= 45)
        {
            zigzag = 1;
        }
        else if (transform.position.y >= 60)
        {
            zigzag = 2;
        }
    }
    public void yellowWallHit()
    {
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, 0.5f, platformLayerMask);

        if (wallInfo.collider == true)
        {

            if (movingRight == false)
            {
                movingRight =true;
            }
            else if (movingRight == true)
            {
                movingRight = false;
            }
        }

    }
}
