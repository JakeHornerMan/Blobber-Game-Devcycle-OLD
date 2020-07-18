using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Animator anim;
    private enum State {ground, jump, fall, absorb}
    public ParticleSystem acid;

    private bool killable = false;
    private bool DisableMovement = false;
    private State action;
    public float speed = 10.00f;
    public float jumpVelocity = 40f;
    public float multiplier = 1.2f;
    private float moveX;
    private float points = 100;
    private int pointSet;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
        Score.scoreAmount = 0;
    }

    void FixedUpdate()
    {
        playerMove();
        anim.SetInteger("state", (int)action);
    }

    public void playerMove()
    {
        if (DisableMovement == false) {
            Jump();
            Movement();
        }
        else if (DisableMovement == true) {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Movement() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(+speed, rb.velocity.y);
                transform.localScale = new Vector2(1, 1);
            }
            else {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
    void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }
        if (!IsGrounded() && Input.GetKeyDown(KeyCode.RightShift)) {
            //increase gravity scale
            FindObjectOfType<Rigidbody2D>().gravityScale = 16;
        }
        //this achieved nothing
        else if (!Input.GetKeyDown(KeyCode.RightShift)) {
            FindObjectOfType<Rigidbody2D>().gravityScale = 8;
        }
    }
    private bool IsGrounded() {

        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = 
            Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeightText, platformLayerMask);

        RaycastHit2D raycastHit2 =
            Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeightText, enemyLayerMask);
        
            Color rayColor;
            if (raycastHit.collider != null)
            {
                action = State.ground;
                jumpVelocity = 40f;
                pointSet = 0;
                rayColor = Color.green;
            }
            
            else if (raycastHit2.collider != null)
            {
                action = State.absorb;
                acid.Play();
                rayColor = Color.blue;
            }
            
            else
            {
                rayColor = Color.red;
                if (rb.velocity.y < .1f)
                {
                    action = State.fall;
                    killable = true;
                }
                else
                {
                    action = State.jump;
                    killable = false;
                }
            }
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0),
            Vector2.down * (bc.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0),
            Vector2.down * (bc.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(0, bc.bounds.extents.x, bc.bounds.extents.y + extraHeightText),
            Vector2.right * (bc.bounds.extents.x), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }



    public void OnCollisionEnter2D(Collision2D other)
    {
        Blue blue = other.gameObject.GetComponent<Blue>();
        if (!IsGrounded() && killable == true && action == State.absorb)
        {
            killable = false;
            if (other.gameObject.tag == "Enemy") //&& blue.mode != State.death)
            {
                killable = false;
                blue.JumpedOn();
                blue.Death();
                coroutine = WaitAndJump(1.5f);//2.2);
                StartCoroutine(coroutine);
                killable = false;
            }
            /*else if (other.gameObject.tag == "Enemy" && action == State.absorb)
            {
                return;
            }*/
        }
    }
    IEnumerator WaitAndJump(float _waitTime)
    {
        DisableMovement = true;
      
        yield return new WaitForSeconds(_waitTime);
        DisableMovement = false;
        JumpMultiplier();
        AddPoints();
        
    }
    public void JumpMultiplier() {
        jumpVelocity = multiplier * jumpVelocity;
        if (jumpVelocity > 150f)
        {
            jumpVelocity = 150f;
        }
        rb.velocity = Vector2.up * jumpVelocity;
    }
    public void AddPoints() {
        pointSet++;
        if (pointSet == 1 || pointSet == 2)
        {
            points = 50;
        }
        else if (pointSet == 3 || pointSet == 4)
        {
            points = 75;
        }
        else if (pointSet == 5 || pointSet == 6)
        {
            points = 125;
        }
        else if (pointSet == 7 || pointSet == 8)
        {
            points = 250;
        }
        else if (pointSet == 9 || pointSet == 10)
        {
            points = 500;
        }
        Score.scoreAmount += points;
    }
}

