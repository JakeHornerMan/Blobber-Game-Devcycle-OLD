using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleblue : MonoBehaviour
{
    public Animator anim;
    public enum State { idle, run }
    private IEnumerator coroutine;
    public State mode;
    public float speed = 20f;
    public bool willRun;
    // Start is called before the first frame update
    void Start()
    {
        mode = State.idle;
        willRun = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetInteger("mode", (int)mode);
        if (willRun == true) {
            run();
        }
    }

    public void run() {
        mode = State.run;
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
