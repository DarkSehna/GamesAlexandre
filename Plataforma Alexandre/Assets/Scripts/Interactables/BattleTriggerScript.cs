using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTriggerScript : MonoBehaviour
{
    public GameObject[] doors;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            for (int i = 0; i < doors.Length; i++) 
            {
                doors[i].SetActive(true);
            }
        }
    }
}
