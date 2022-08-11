using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeverScript : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerStay2D(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if(player != null)
        {
            if(player.inputHandler.interactInput)
            {
                door.SetActive(false);
            }
        }
    }
}
