using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_scr : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var checkpointPos = collision.GetComponent<Player>();
            checkpointPos.playerData.lastCheckpointPos = gameObject.transform.position;
        }
    }
}
