using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool canDoubleJump = true;
    private int jumpCount = 0; 
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetBool("IsJumping", !IsGrounded());

        if (Input.GetMouseButtonDown(0))
        {
            if (IsGrounded())
            {
                // Normal jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                SoundManagerScript.PlaySound("Jump1");
                jumpCount = 1; // Set jump count to 1 (normal jump)
            }
            else if (jumpCount == 1)
            {
                // Double jump (only allowed if the player is in the air and has already jumped once)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                SoundManagerScript.PlaySound("Jump2");
                jumpCount = 2; // Set jump count to 2 (double jump)
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Reset jump count when grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded())
        {
            jumpCount = 0; // Reset jump count when touching the ground
        }
    }
}
