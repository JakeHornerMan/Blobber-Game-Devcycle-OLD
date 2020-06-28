using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    //private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Animator anim;
    public enum State { run, death }
    private IEnumerator coroutine;
    [SerializeField] private LayerMask platformLayerMask;
    public GameObject Spawner;
    spawnerBlue mySpawnScript;

    State mode = State.run;
    public float speed;
    private bool movingRight;
    public Transform wallDetection;
    float chance;
    bool DisableMovement = false;
    private int blueNum = 10;


    void Start()
    {
        mySpawnScript = Spawner.GetComponent<spawnerBlue>();
        //rb = transform.GetComponent<Rigidbody2D>();
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
        else if (DisableMovement == true) {

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
            transform.Translate(new Vector2 (0f,0f));
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
            //Spawner1.GetCompnent<Spawner1>().spawnBlue();
 
        }
    }

    public void JumpedOn(){
        mode = State.death;
        mySpawnScript.opening();
    }
}
