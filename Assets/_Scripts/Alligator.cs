using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alligator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isAttacking = false;
    private int chanceToAttack = 40; // 1 in X chance each second

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.2f);   
        StartCoroutine(GatorCheck());
    }

    IEnumerator GatorCheck()
    {
        Debug.Log("enter check");
        while (!isAttacking)
        {
            yield return new WaitForSeconds(1f);
            int chance = Random.Range(0, chanceToAttack); // independently defined for debugging purposes
            Debug.Log(chance);
            if (chance == 1)
            {
                Debug.Log("enter attack");
                isAttacking = true;
                AttackBoat();
            }
        }
    }

    void AttackBoat()
    {
        Debug.Log("Gator Attacking!");
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        StartCoroutine(HitGator());
    }

    IEnumerator HitGator()
    {
        int hitCount = Random.Range(10, 15);

        while (hitCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hitCount--;
                spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                Debug.Log("you diggin in me " + "; Hits remaining: " + hitCount);
            }
            yield return null;
        }
        StartCoroutine(Retreat());
    }
    
    IEnumerator Retreat()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.6f);
        isAttacking = false;
        yield return new WaitForSeconds(2f); // grace period before next attack
        StartCoroutine(GatorCheck());
    }
}
