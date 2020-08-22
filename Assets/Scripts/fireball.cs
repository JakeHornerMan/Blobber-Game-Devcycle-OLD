using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    Vector3 ShotPos;
    Vector3 targetPos;
    GameObject player;

    public Animator anim;
    private enum State { fireball, explode }
    private State action;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ShotPos = player.transform.position;
        action = State.fireball;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(ShotPos, 15f);
        coroutine = WaitAndExplode(3.5f);
        StartCoroutine(coroutine);
    }
    private void Move(Vector3 target, float movementSpeed)
    {
        //Move
        transform.position += (target - transform.position).normalized * movementSpeed * Time.deltaTime;
    }
    IEnumerator WaitAndExplode(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        action = State.explode;
        anim.SetInteger("state", (int)action);
        coroutine = WaitAndDestroy(.5f);
        StartCoroutine(coroutine);
        
    }
    IEnumerator WaitAndDestroy(float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);
        Destroy(this.gameObject);
    }
}
