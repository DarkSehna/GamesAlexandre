using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    private Player player;
    public int collectedWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            player.inputHandler.collectedWeapons[collectedWeapon] = true;
            Destroy(this.gameObject);
        }
    }
}
