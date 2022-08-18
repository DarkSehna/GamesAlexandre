using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region Public Variables
    [Header("Game Objects")]
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    [Header("Floats")]
    public float bulletSpeed = 60f;
    public float shotTimerTime = 60f;
    public float retrieveTimerTime = 60f;

    [Header("Ints")]
    public int bouncerAmmo = 3;
    public int maxShots;
    
    [Header("Lists")]
    public List<GameObject> bouncers;

    [Header("Bools")]
    public bool hasBouncePower = false;
    #endregion

    #region Private Variables
    private Vector3 target;
    private bool canShoot = true;
    private bool canRetrieve = true;
    private float shotTimer;
    private float retrieveTimer;
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        
        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        bulletStart.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetMouseButtonDown(0) && canShoot && hasBouncePower && maxShots < bouncerAmmo)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            maxShots++;
            FireBullet(direction, rotationZ);
            canShoot = false;
            canRetrieve = false;
            shotTimer = shotTimerTime;
            retrieveTimer = retrieveTimerTime;
        }

        if (Input.GetKeyDown("q") && maxShots != 0 && canRetrieve)
        {
            for (int i = 0; i < bouncers.Count; i++)
            {
                Destroy(bouncers[i]);
            }
            bouncers.Clear();
            maxShots = 0;
        }

        if (!canShoot)
        {
            shotTimer -= Time.deltaTime;
            if (shotTimer <= 0f)
            {
                canShoot = true;
            }
        }

        if (!canRetrieve)
        {
            retrieveTimer -= Time.deltaTime;
            if (retrieveTimer <= 0f)
            {
                canRetrieve = true;
            }
        }
    }

    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
