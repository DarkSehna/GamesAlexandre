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
    public float horizontalForce = 50f;

    public Vector2 wallNormal;
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

        //Debug.Log("x " + wallNormal.x);
        //Debug.Log("y " + wallNormal.y);
    }

    //Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            activateTime -= Time.deltaTime;
            if (activateTime <= 0f)
            {
                box.enabled = true;
                isActive = true;
            }
        }
        else
        {
            destroyTime -= Time.deltaTime;
            if (destroyTime <= 0f)
            {
                box.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            var playerMovement = collision.GetComponent<Player>().Core.Movement;
            float dot = Vector2.Dot(Vector2.up, wallNormal);
            var playerDirection = SetBounceDirection(wallNormal, dot);
            //Debug.Log(playerDirection);
            //if (Input.GetButton("Jump"))
            //{
            player.stateMachine.ChangeState(player.inAirState);
            Debug.Log(dot);
            if(dot < 0.8f && dot > -0.8f)
            {
                playerMovement.SetVelocity(horizontalForce, playerDirection);
                playerMovement.CanSetVelocity = false;
            }
            else
            {
                playerMovement.SetVelocity(jumpForce, playerDirection);
            }
            Debug.DrawLine(transform.position, (Vector2)transform.position + playerMovement.currentVelocity, Color.green, 5f);
            //}
            //else
            //{
            //    player.stateMachine.ChangeState(player.inAirState);
            //    playerMovement.SetVelocity(jumpForce, playerDirection);
            //    if (wallNormal.x != 0)
            //    {
            //        playerMovement.CanSetVelocity = false;
            //    }
            //    Debug.DrawLine(transform.position, (Vector2)transform.position + playerMovement.currentVelocity, Color.green, 5f);
            //}
        }
    }

    private Vector2 SetBounceDirection(Vector2 velocity, float dot)
    {
        Vector2 direction;

        if (dot < 0.8f && dot > -0.8f)
        {
            direction = velocity + (Vector2.up * new Vector2(0, 0.5f));
        }
        else
        {
            direction = Vector2.Reflect(-velocity, transform.up);
        }

        return direction;
    }
}
