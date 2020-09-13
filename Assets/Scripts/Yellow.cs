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
    public float timebetweenshots;
    [SerializeField] private LayerMask platformLayerMask;
    private IEnumerator coroutine;
    [SerializeField] private GameObject fireballPrefab;
    public GameObject gun;
    Vector3 target;

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
        Shooting();
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
            //transform.Rotate(0f, 180f, 0f);
        }
        else if (movingRight == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
            //transform.Rotate(0f, 0f, 0f);
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
    public void Shooting() {
        coroutine = ShootTimer(timebetweenshots);
        StartCoroutine(coroutine);
    }
    IEnumerator ShootTimer(float _waitTime) {
        yield return new WaitForSeconds(_waitTime);
        Shoot();
    }
    public void Shoot() {
        GameObject f = Instantiate(fireballPrefab) as GameObject;
        SoundManager.PlaySound("shoot");
        target = gun.transform.position;
        f.transform.position = target;
        Shooting();
    }
}
