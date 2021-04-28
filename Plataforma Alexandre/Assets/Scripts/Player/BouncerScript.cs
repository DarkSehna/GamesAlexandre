using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    public float targetTime = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
