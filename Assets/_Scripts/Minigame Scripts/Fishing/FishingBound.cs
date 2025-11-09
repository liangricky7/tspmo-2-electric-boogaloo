using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBound : MonoBehaviour
{
    [SerializeField] private SpriteRenderer keySprite;
    [SerializeField] private SpriteRenderer rodSprite;
    private bool playerInArea;

    void Start()
    {
        keySprite.color = new Color(1f, 1f, 1f, 0f);
        playerInArea = false;
    }

    void OnEnable()
    {
        // Subscribe when enabled
        GameManager.Instance.ExitFishEvent.AddListener(ResetFishing);
    }

    void OnDisable()
    {
        // IMPORTANT: Unsubscribe to prevent memory leaks
        GameManager.Instance.ExitFishEvent.RemoveListener(ResetFishing);
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
            rodSprite.color = new Color(1f, 1f, 1f, 0f);
            keySprite.color = new Color(1f, 1f, 1f, 0f);
        }
    }
    
    void ResetFishing()
    {
        rodSprite.color = new Color(1f, 1f, 1f, 1f);
    }
}
