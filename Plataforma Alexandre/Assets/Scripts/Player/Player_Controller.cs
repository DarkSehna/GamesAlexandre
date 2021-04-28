using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Private Variables
    private float moveInputDirection;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    #endregion

    #region Public Variables
    public float moveSpeed;
    public float jumpForce;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
        checkMoveDirection();
    }

    private void FixedUpdate()
    {
        applyMovement();
    }

    private void checkInput()
    {
        moveInputDirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }

    private void applyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * moveInputDirection, rb.velocity.y);
    }

    private void checkMoveDirection()
    {
        if (isFacingRight && moveInputDirection < 0)
        {
            flip();
        }
        else if (!isFacingRight && moveInputDirection > 0)
        {
            flip();
        }
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
