using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveForce = 5f;
    public float maxHorizontalSpeed = 10f;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    public bool isGrounded = true;
    private bool facingRight = true; // Track player facing direction

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveForce, rb.velocity.y);

        // Flip character sprite if moving left
        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        // Set animation parameters
        anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
            isGrounded = true;
            anim.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
