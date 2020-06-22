using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Animator anim;
    private enum State { run, death }
    private IEnumerator coroutine;
    [SerializeField] private LayerMask platformLayerMask;

    private State mode = State.run;
    public float speed;
    private bool movingRight;
    public Transform wallDetection;
    public float chance;
    public bool DisableMovement = false;


    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
        chance = Random.Range(1f, 100f);
        if (chance <= 50)
        {
            movingRight = true;
        }
        else if (chance >= 50)
        {
            movingRight = false;
        }
    }
     // Update is called once per frame
    void FixedUpdate() {
        anim.SetInteger("blueState", (int)mode);
        blueDirection();
        if (DisableMovement == false)
        {
            blueMove();
        }
    }

    public void blueMove() {

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
        else if (DisableMovement == true)
        {
            
        }
    }

    public void blueDirection() {

        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, 0.5f, platformLayerMask);

        if (wallInfo.collider == true) {
            
            if (movingRight == true)
            {
                movingRight = false;
            }
            else if (movingRight == false)
            {
                movingRight = true;
            }
        }
        
    }

    IEnumerator WaitAndDestroy(float _waitTime)
    {
        DisableMovement = true;
        yield return new WaitForSeconds(_waitTime);
        
        Destroy(this.gameObject);
    }

    public void Death()
    {
        if (mode == State.death)
        {
            coroutine = WaitAndDestroy(3f);
            StartCoroutine(coroutine);
        }
    }

    public void JumpedOn(){
        mode = State.death;
    }
}
