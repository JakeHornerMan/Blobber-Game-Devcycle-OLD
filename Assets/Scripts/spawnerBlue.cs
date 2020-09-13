using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBlue : MonoBehaviour
{
    private IEnumerator coroutine;
    [SerializeField] private GameObject bluePrefab;
    public Animator anim;
    public enum State { closed, opening, open, closing }
    public State mode;

    // Start is called before the first frame update

    void Start() {
        
    }

    public void FixedUpdate() {
        anim.SetInteger("state", (int)mode);
    }

    public void opening() {
        coroutine = OpeningandWait(1.5f);
        StartCoroutine(coroutine);
    }
    IEnumerator OpeningandWait(float _waitTime)
    {
        mode = State.opening;
        yield return new WaitForSeconds(_waitTime);
        open();
    }

    void open() {
        
        coroutine = WaitAndCreate(0.3f);
        StartCoroutine(coroutine);
        SoundManager.PlaySound("spawnDing");
    }
 
    IEnumerator WaitAndCreate(float _waitTime)
    {
        mode = State.open;
        GameObject b = Instantiate(bluePrefab) as GameObject;
        b.transform.position = new Vector3(8.5f, -3.98f, 0f);
        yield return new WaitForSeconds(_waitTime);
        closing();
        
    }
    void closing() {
        coroutine = ClosingAndWait(1.1f);
        StartCoroutine(coroutine);
    }
    IEnumerator ClosingAndWait(float _waitTime)
    {
        mode = State.closing;
        yield return new WaitForSeconds(_waitTime);
        close();
    }
    void close() {
        mode = State.closed;
    }
}