using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float spd;
    public float jumpF;
    Rigidbody2D rig;
    Animator anim;
    public bool isjump;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

     void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * spd;
        //andar para direita
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        //andar para esquerda
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Walk", false);
        }
    }
    void jump()
    { 
        if (Input.GetButtonDown("Jump") && !isjump) 
        {
            rig.AddForce(new Vector2(0f,jumpF),ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isjump = false;
            anim.SetBool("Jump", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isjump = true;
        }
    }
}
