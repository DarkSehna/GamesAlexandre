using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    #region Public Variables
    [Header("Floats")]
    public float destroyTime = 60f;

    [Header("Game Objects")]
    public GameObject Bouncer;
    #endregion

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            var a = Instantiate(Bouncer as GameObject, this.transform.position, new Quaternion());
            Player.GetComponent<PlayerShoot>().bouncers.Add(a);
            Destroy(gameObject);
        }
        /*if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/
    }
}
