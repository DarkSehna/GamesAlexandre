using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePower_scr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            var Bounce = collision.GetComponent<PlayerShoot>();
            Bounce.hasBouncePower = true;
            Destroy(gameObject);
        }
    }
}
