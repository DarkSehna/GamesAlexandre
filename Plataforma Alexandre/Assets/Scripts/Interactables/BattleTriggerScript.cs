using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BattleTriggerScript : MonoBehaviour
{
    private Collider2D trigger;

    public DoorManagerScript manager;
    public GameObject[] doors;

    public List<GameObject> enemyList;
    public bool enemySpawning;

    public CinemachineVirtualCamera roomCamera;

    private void Awake()
    {
        manager.OpenDoors(doors);

        trigger = gameObject.GetComponent<BoxCollider2D>();
        trigger.enabled = true;
    }

    private void Update()
    {
        if(enemyList.Count == 0)
        {
            manager.OpenDoors(doors);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !enemySpawning)
        {
            enemyList.Add(collision.gameObject);
        }

        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            if(enemySpawning)
            {
                SpawnEnemies();
            }

            manager.CloseDoors(doors);
            roomCamera.m_Lens.OrthographicSize += 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyList.Remove(collision.gameObject);
        }

        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            manager.OpenDoors(doors);
            roomCamera.m_Lens.OrthographicSize -= 10;
        }
    }

    private void SpawnEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            enemy.SetActive(true);
        }
    }
}
