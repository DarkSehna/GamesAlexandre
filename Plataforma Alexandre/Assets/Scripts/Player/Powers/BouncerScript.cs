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

        Debug.Log(wallNormal);
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
            var player = collision.GetComponent<Player>();
            var playerMovement = collision.GetComponent<Player>().Core.Movement;
            var playerDirection = SetBounceDirection(-wallNormal);
            Debug.Log(playerDirection);
            if (Input.GetButton("Jump"))
            {
                player.stateMachine.ChangeState(player.inAirState);
                playerMovement.SetVelocity(jumpForce, playerDirection);
                playerMovement.CanSetVelocity = false;
                Debug.DrawLine(transform.position, (Vector2)transform.position + playerMovement.currentVelocity, Color.green, 5f);
            }
            else
            {
                player.stateMachine.ChangeState(player.inAirState);
                playerMovement.SetVelocity(jumpForce, playerDirection);
                playerMovement.CanSetVelocity = false;
                Debug.DrawLine(transform.position, (Vector2)transform.position + playerMovement.currentVelocity, Color.green, 5f);
            }
        }
    }

    private Vector2 SetBounceDirection(Vector2 velocity)
    {
        var direction = Vector2.Reflect(velocity, transform.up);

        //if(direction)

        return direction;
    }
}
