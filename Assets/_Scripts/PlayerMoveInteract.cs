using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveInteract : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = 0f;
        
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;
        
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
