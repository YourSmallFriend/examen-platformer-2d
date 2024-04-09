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
        rb.velocity = new Vector2(moveHorizontal * moveForce, rb.velocity.y);
        float currentMoveForce = Input.GetKey(KeyCode.LeftShift) ? sprintForce : moveForce;
        rb.velocity = new Vector2(moveHorizontal * currentMoveForce, rb.velocity.y);

        // Flip character sprite if moving left
        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        // Check if player's speed is greater than 1
        bool isRunning = Mathf.Abs(rb.velocity.x) > 1;

        // Set animation parameters
        anim.SetBool("run", isRunning);
        anim.SetBool("isGrounded", IsGrounded);

        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
