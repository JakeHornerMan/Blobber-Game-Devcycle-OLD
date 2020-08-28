
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;

    public bool Damagable = true;
    private IEnumerator coroutine;

    void Start(){
        
        /*if (health > numOfHearts || health < numOfHearts)
        {
            //health = numOfHearts;
        }*/
    }

    void Update() {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void Damage() {

        if (Damagable == true) {
            health = health - 1;
            coroutine = InVunrable(2f);
            StartCoroutine(coroutine);
        }
        if (health == 0)
        {
            DeathEnding();
        }
    }

    IEnumerator InVunrable(float _waitTime)
    {
        Damagable = false;
        GetComponent<Player_Move>().takingDamage();
        yield return new WaitForSeconds(_waitTime);
        Damagable = true;
    }

    public void DeathEnding(){
        FindObjectOfType<GameManager>().GameOver();
    }
}
