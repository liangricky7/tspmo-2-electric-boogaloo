using System.Collections;
using UnityEngine;

public class Alligator : MonoBehaviour
{
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject PlayerReference;
    [SerializeField]
    SpriteRenderer keySprite;
    SpriteRenderer spriteRenderer;
    bool playerInTrigger = false; // player is in trigger zone, but gator is not necessarily attacking
    bool playerInArea = false; // player is in trigger zone and gator is attacking
    bool playerIsAttacking = false;
    public bool isAttacking = false; // gator is attacking
    private int chanceToAttack = 3; // 1 in X chance each second

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.2f);  
        keySprite.color = new Color(1f, 1f, 1f, 0.0f);    
    }
    void OnEnable()
    {
        // Turn On
        GameManager.Instance.StopEvent.AddListener(StartGator);
        // Turn Off
        GameManager.Instance.ExitStopEvent.AddListener(StopGator);
    }

    void OnDisable()
    {
        // IMPORTANT: Unsubscribe to prevent memory leaks
        GameManager.Instance.StopEvent.RemoveListener(StartGator);
        // Turn Off
        GameManager.Instance.ExitStopEvent.RemoveListener(StopGator);
    }

    void StartGator()
    {
        // Debug.Log("start gator");
        StartCoroutine(GatorCheck());
    }

    void StopGator()
    {
        // Debug.Log("stop gator");
        StopAllCoroutines();
        playerInTrigger = false;
        playerInArea = false;
        playerIsAttacking = false;
        isAttacking = false;
    }
    
    IEnumerator GatorCheck()
    {
        // Debug.Log("enter check");
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
        int hitCount = Random.Range(4, 8);
        Animator animator = PlayerReference.GetComponent<Animator>(); 
        PlayerMoveInteract playerMove = PlayerReference.GetComponent<PlayerMoveInteract>();
        playerMove.ChangeGatorArm(); // change to hammer arm

        while (hitCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //animate hit
                animator.SetBool("BeatGator", true);
                yield return new WaitUntil(() => playerMove.animationDone);
                StartCoroutine(mainCamera.GetComponent<ScreenShake>().Shake(.5f, .1f));
                animator.SetBool("BeatGator", false);

                hitCount--;
                spriteRenderer.color = new Color(1f, 0f, 0f, 1f);
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                Debug.Log("you diggin in me " + "; Hits remaining: " + hitCount);
            }
            yield return null;
        }
        PlayerReference.GetComponent<PlayerMoveInteract>().ChangeGatorArm();  // change back
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
