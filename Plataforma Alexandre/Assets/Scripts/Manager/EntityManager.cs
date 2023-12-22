using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public GameObject[] entities;
    public float[] entityIDs;

    private void Start()
    {
        entities = GameObject.FindGameObjectsWithTag("Enemy");
        CreateID();

        for (int i = 0; i < entities.Length; i++)
        {
            entities[i].GetComponent<Entity>().entityID = entityIDs[i];
        }
    }

    private void CreateID()
    {
        var length = entities.Length;
        entityIDs = new float[length]; 

        for(int i = 0; i < entities.Length; i++)
        {
            entityIDs[i] = Random.value;
        }
    }
}
