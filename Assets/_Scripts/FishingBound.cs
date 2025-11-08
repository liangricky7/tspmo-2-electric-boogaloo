using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBound : MonoBehaviour
{
    private BoxCollider2D fishingArea;
    [SerializeField] private SpriteRenderer keySprite;
    private bool playerInArea;

    void Start()
    {
        fishingArea = GetComponent<BoxCollider2D>();
        keySprite.color = new Color(1f, 1f, 1f, 0f);
        playerInArea = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        keySprite.color = new Color(1f, 1f, 1f, 1f);
        if (collision.gameObject.tag == "Player") playerInArea = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        keySprite.color = new Color(1f, 1f, 1f, 0f);
        if (collision.gameObject.tag == "Player") playerInArea = false;
    }
    
    void Update()
    {
        if (playerInArea && Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.FishState();
            keySprite.color = new Color(1f, 1f, 1f, 0f);
        }
    }

}
