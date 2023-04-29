using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacmanMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to change Pac-Man's movement speed
    public LayerMask wallLayer; // Set this to the layer that contains the walls

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveDirection;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get the horizontal and vertical input axis values
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set the move direction based on the input axis values
        if (horizontalInput != 0f)
        {
            moveDirection = new Vector2(horizontalInput, 0f).normalized;
            animator.SetFloat("Xdir", horizontalInput);
            animator.SetFloat("Ydir", 0f);
        }
        else if (verticalInput != 0f)
        {
            moveDirection = new Vector2(0f, verticalInput).normalized;
            animator.SetFloat("Xdir", 0f);
            animator.SetFloat("Ydir", verticalInput);
        }
        else
        {
            animator.SetFloat("Xdir", 0f);
            animator.SetFloat("Ydir", 0f);
        }

        // Check if Pac-Man can move in the desired direction
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1f, wallLayer);
        if (hit.collider != null)
        {
            moveDirection = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        // Move Pac-Man in the move direction
        rb.velocity = moveDirection * moveSpeed;

      
    }
}
