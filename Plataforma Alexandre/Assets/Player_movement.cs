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
    public GameObject Bullet;
    Vector2 lookDirection;
    float lookAngle;
    public Transform player;
    public float offSet;

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
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        player.rotation = quaternion.Euler(0f, 0f, lookAngle + offSet);
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
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
    void FireBullet()
    {
        GameObject FireBullet = Instantiate(Bullet, player.position, player.rotation);
        FireBullet.GetComponent<Rigidbody2D>().velocity = player.up * 10f;
    }
  
}
