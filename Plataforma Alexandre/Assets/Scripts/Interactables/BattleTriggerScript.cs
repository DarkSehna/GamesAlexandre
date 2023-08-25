using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTriggerScript : MonoBehaviour
{
    private Collider2D trigger;
    public DoorManagerScript manager;
    public GameObject[] doors;
    public GameObject[] enemies;

    private int killCount;
    private int enemyCount;

    private void Awake()
    {
        manager.OpenDoors(doors);

        trigger = gameObject.GetComponent<BoxCollider2D>();
        trigger.enabled = true;

        enemyCount = enemies.Length;
        killCount = enemies.Length - enemies.Length;
    }

    private void Update()
    {
        foreach(GameObject enemy in enemies)
        {
            if(enemy.activeSelf == false)
            {
                killCount++;
            }
        }

        

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            manager.CloseDoors(doors);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (killCount >= enemyCount)
        {
            manager.OpenDoors(doors);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            manager.OpenDoors(doors);
        }

        if (killCount >= enemyCount)
        {
            trigger.enabled = false;
        }
    }
}
