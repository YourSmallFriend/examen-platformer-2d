using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveForce = 5f;
    public float sprintForce = 7f; // Additional force for sprinting
    public float maxHorizontalSpeed = 7f;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    public bool IsGrounded;
    private bool facingRight = true; // Track player facing direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate current move force based on whether sprint key is pressed
        float currentMoveForce = Input.GetKey(KeyCode.LeftShift) && IsGrounded ? sprintForce : moveForce;
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(rb.velocity.x) >= 4f;

        if (Input.GetKey(KeyCode.Space) && IsGrounded){
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        anim.SetTrigger("jump");}

        // Set animation parameters
        anim.SetBool("run", isRunning);

        // Apply horizontal movement
        rb.velocity = new Vector2(moveHorizontal * currentMoveForce, rb.velocity.y);

        // Limit maximum horizontal speed
        float clampedVelocityX = Mathf.Clamp(rb.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);
        rb.velocity = new Vector2(clampedVelocityX, rb.velocity.y);

        // Flip character sprite if moving left
        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        // Check if player is walking (moving horizontally)
        bool isWalking = Mathf.Abs(rb.velocity.x) > 0.1f && Mathf.Abs(rb.velocity.x) < 4f;

        // Set animation parameters
        anim.SetBool("walk", isWalking);
    }

    void Flip()
    {
        // Flip the player horizontally
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        // Update facing direction
        facingRight = !facingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            IsGrounded = true;
            anim.SetBool("jump", false);
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            anim.SetBool("WallPlay", true);
            anim.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            anim.SetBool("WallPlay", false);
        }
    }
}
