using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float moveSpeed = 2f;
    public Vector2 direction;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        moveCharacter(direction.x);
    }

    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

    }
}

