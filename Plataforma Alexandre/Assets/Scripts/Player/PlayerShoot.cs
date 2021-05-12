using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public float bulletSpeed = 60f;
    private Vector3 target;
    public bool canShoot = false;
    public int bouncerAmmo = 3;
    public List<GameObject> bouncers;
    public int maxShots;
    
    // Start is called before the first frame update
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

        if (Input.GetMouseButtonDown(0) && canShoot && maxShots < bouncerAmmo)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            maxShots++;
            FireBullet(direction, rotationZ);
        }

        if (Input.GetKeyDown("q") && maxShots == bouncerAmmo)
        {
            for (int i = 0; i < bouncers.Count; i++)
            {
                Destroy(bouncers[i]);
            }
            bouncers.Clear();
            maxShots = 0;
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
