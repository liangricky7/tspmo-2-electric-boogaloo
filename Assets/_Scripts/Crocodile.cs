using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isAttacking = false;
    private float chanceToAttack = 60f; // 1 in X chance each second

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);   
        StartCoroutine("CrocCheck");
    }

    IEnumerable CrocCheck()
    {
        Debug.Log("Croc Checking...");
        while (!isAttacking)
        {
            yield return new WaitForSeconds(1f);
            if (Random.Range(0, chanceToAttack) == 1)
            {
                AttackBoat();
            }
        }
    }

    void AttackBoat()
    {
        isAttacking = true;
        Debug.Log("Croc Attacking!");
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        StartCoroutine(HitCroc());
    }

    IEnumerator HitCroc()
    {
        int hitCount = Random.Range(10, 20);

        while (hitCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hitCount--;
                spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
            }
        }
        Retreat();
        yield return 0;
    }
    
    void Retreat()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
        isAttacking = false;
    }
}
