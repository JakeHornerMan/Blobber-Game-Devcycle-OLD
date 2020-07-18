using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    public float speed;
    public int zigzag;
    public Transform wallDetection;
    private int movingRight;
    [SerializeField] private LayerMask platformLayerMask;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(new Vector3(-7f, 43.3f, 0f) * speed * Time.deltaTime);
        //transform.Translate(0, speed * Time.deltaTime, 0);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        zigzag = Random.Range(1, 2);
        movingRight = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public void Movement() {
        if (movingRight == 1)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (movingRight == 2)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
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

            if (movingRight == 2)
            {
                movingRight =1;
            }
            else if (movingRight == 1)
            {
                movingRight = 2;
            }
        }

    }
}
