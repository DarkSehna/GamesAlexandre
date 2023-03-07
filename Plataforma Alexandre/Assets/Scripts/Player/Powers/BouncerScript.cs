using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    #region Public Variables
    [Header("Floats")]
    public float activateTime = 60f;
    public float destroyTime = 60f;
    public float jumpForce = 40f;
    #endregion

    #region Private Variables
    private Collider2D box;
    private bool isActive = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<Collider2D>();
        isActive = true;
        box.enabled = true;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(!isActive)
    //    {
    //        activateTime -= Time.deltaTime;
    //        if (activateTime <= 0f)
    //        {
    //            box.enabled = true;
    //            isActive = true;
    //        }
    //    }
    //    else
    //    {
    //        destroyTime -= Time.deltaTime;
    //        if(destroyTime <= 0f)
    //        {
    //            box.enabled = false;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var playerMovement = collision.GetComponent<Player>().Core.Movement;
            if (Input.GetButton("Jump"))
            {
                //rb.velocity = new Vector2(rb.velocity.x, jumpForce + 10);
                playerMovement.SetVelocity(jumpForce, Vector2.Reflect(playerMovement.currentVelocity, transform.up).normalized);
                Debug.DrawLine(transform.position, (Vector2)transform.position + playerMovement.currentVelocity, Color.green, 5f);
            }
            else
            {
                //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                playerMovement.SetVelocity(jumpForce, Vector2.Reflect(playerMovement.currentVelocity, transform.up).normalized);
                Debug.DrawLine(transform.position, (Vector2)transform.position + playerMovement.currentVelocity, Color.green, 5f);
            }
        }
    }
}
