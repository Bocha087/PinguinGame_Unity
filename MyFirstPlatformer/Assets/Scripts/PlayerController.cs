using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private SpriteRenderer sprite;

    private Animator animator;

    private BoxCollider2D boxCol;

    private float dirX = 0f;

    [SerializeField] private LayerMask jumpOnBackground;

    [SerializeField] private float walkSpeed = 7.5f;

    [SerializeField] private float jumpForce = 5f;

    private enum MovementState { idle , running , jump , fall}

    [SerializeField] private AudioSource audioJumpEffect;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        audioJumpEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);


        if (Input.GetKeyDown("space") && isGrounded())
        {
            audioJumpEffect.Play();
            rb.velocity = new Vector2 (rb.velocity.y, jumpForce); 
        }

        UpdateAnim();
    }
    private void UpdateAnim()
    {
        MovementState state;

        if (dirX > 0f )
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f )
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }


        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        animator.SetInteger("state", (int)state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpOnBackground);
    }
}
