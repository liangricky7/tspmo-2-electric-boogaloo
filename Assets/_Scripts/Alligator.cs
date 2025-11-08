using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isAttacking = false;
    private int chanceToAttack = 3; // 1 in X chance each second

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);   
        StartCoroutine(HitCroc());
    }

    IEnumerator CrocCheck()
    {
        while (!isAttacking)
        {
            yield return new WaitForSeconds(1f);
            int chance = Random.Range(1, chanceToAttack); // independently defined for debugging purposes
            if (chance == 1)
            {
                isAttacking = true;
                AttackBoat();
            }
        }
    }

    void AttackBoat()
    {
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
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }
            yield return null;
        }
        Retreat();
    }
    
    void Retreat()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
        isAttacking = false;
    }
}
