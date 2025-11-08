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
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 for left, 1 for right, 0 for no input
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
