using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveForce = 5f;
    public float sprintForce = 7f;
    public float maxHorizontalSpeed = 7f;
    public float jumpHeight = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    public bool IsGrounded;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float currentMoveForce = Input.GetKey(KeyCode.LeftShift) && IsGrounded ? sprintForce : moveForce;
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(rb.velocity.x) >= 4f;

        if (Input.GetKey(KeyCode.Space) && IsGrounded){
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        anim.SetTrigger("jump");}
        anim.SetBool("run", isRunning);
        rb.velocity = new Vector2(moveHorizontal * currentMoveForce, rb.velocity.y);
        float clampedVelocityX = Mathf.Clamp(rb.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);
        rb.velocity = new Vector2(clampedVelocityX, rb.velocity.y);

        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        bool isWalking = Mathf.Abs(rb.velocity.x) > 0.1f && Mathf.Abs(rb.velocity.x) < 4f;

        anim.SetBool("walk", isWalking);
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

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
