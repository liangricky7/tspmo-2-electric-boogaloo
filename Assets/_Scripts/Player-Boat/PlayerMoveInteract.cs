using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInteract : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody2D rb;
    private bool canMoving = true;
    private bool fishingArmOut = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        // Turn On
        GameManager.Instance.FishEvent.AddListener(TurnOff);
        // Turn Off
        GameManager.Instance.ExitFishEvent.AddListener(TurnOn);

        // Fishing Arm
        GameManager.Instance.FishEvent.AddListener(ChangeArm);
        GameManager.Instance.ExitFishEvent.AddListener(ChangeArm);
    }

    void OnDisable()
    {
        // Turn On
        GameManager.Instance.FishEvent.RemoveListener(TurnOff);
        // Turn Off
        GameManager.Instance.ExitFishEvent.RemoveListener(TurnOn);
        // Fishing Arm
        GameManager.Instance.FishEvent.RemoveListener(ChangeArm);
        GameManager.Instance.ExitFishEvent.RemoveListener(ChangeArm);
    }

    void Update()
    {
        if (!canMoving) return;
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void TurnOn()
    {
        canMoving = true;
    }

    void TurnOff()
    {
        canMoving = false;
    }
    
    void ChangeArm()
    {
        fishingArmOut = !fishingArmOut;
        if (!fishingArmOut)
        {
            // Change to fishing arm
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            // Change to normal arm
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
