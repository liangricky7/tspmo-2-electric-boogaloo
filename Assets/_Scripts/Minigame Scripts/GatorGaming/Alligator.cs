using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alligator : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer keySprite;
    SpriteRenderer spriteRenderer;
    bool playerInTrigger = false; // player is in trigger zone, but gator is not necessarily attacking
    bool playerInArea = false; // player is in trigger zone and gator is attacking
    bool playerIsAttacking = false;
    bool isAttacking = false;
    private int chanceToAttack = 3; // 1 in X chance each second

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.2f);  
        keySprite.color = new Color(1f, 1f, 1f, 0.0f);    
        StartCoroutine(GatorCheck());
    }
    void OnEnable()
    {
        // Subscribe when enabled
        GameManager.Instance.StopEvent.AddListener(StartGator);
    }

    void OnDisable()
    {
        // IMPORTANT: Unsubscribe to prevent memory leaks
        GameManager.Instance.StopEvent.RemoveListener(StartGator);
    }

    void StartGator()
    {
        StartCoroutine(GatorCheck());
    }

    IEnumerator GatorCheck()
    {
        Debug.Log("enter check");
        while (!isAttacking)
        {
            yield return new WaitForSeconds(1f);
            int chance = Random.Range(0, chanceToAttack); // independently defined for debugging purposes
            // Debug.Log(chance);
            if (chance == 1)
            {
                // Debug.Log("enter attack");
                isAttacking = true;
                AttackBoat();
            }
        }
    }

    void AttackBoat()
    {
        // Debug.Log("Gator Attacking!");
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    // code for button to show to enter hit mode
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (isAttacking && collision.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
            if (isAttacking)
            {
                playerInArea = false;
                keySprite.color = new Color(1f, 1f, 1f, 0f);    
            }
        }
    }

    void Update()
    {
        if (playerInTrigger && isAttacking && !playerIsAttacking) // reveals key prompt when gator is attacking and player in area; doing this by trigger doesnt work
        {
            playerInArea = true;
            keySprite.color = new Color(1f, 1f, 1f, 1f);
        }

        if (!playerIsAttacking && playerInArea && Input.GetKeyDown(KeyCode.E))
        {
            playerIsAttacking = true;
            keySprite.color = new Color(1f, 1f, 1f, 0f);
            StartCoroutine(HitGator());
        }
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

    public void selfDelete()
    {
        Destroy(this); //Self-deletes gator when boat is moving
    }
}
