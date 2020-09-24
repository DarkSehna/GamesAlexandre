using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbiont_scr : MonoBehaviour
{
    SpriteRenderer sr;
    CircleCollider2D circle;
    public GameObject collected;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            Destroy(gameObject, .3f);
        }
    } 
}
