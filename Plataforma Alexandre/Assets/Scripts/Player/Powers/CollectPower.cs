using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPower : MonoBehaviour
{
    private Player player;
    public int collectedPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            player.inputHandler.collectedPowers[collectedPower] = true;
            Destroy(this.gameObject);
        }
    }
}
