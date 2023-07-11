using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : Projectile
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.transform.tag != "Player")
        {
            if (objectToSpawn != null)
            {
                //var bouncer = Instantiate(objectToSpawn, collision.contacts[0].point, Quaternion.identity, powerRepository.transform).transform.up = collision.contacts[0].normal;
                GameObject bouncer = Instantiate(objectToSpawn, collision.contacts[0].point, Quaternion.identity, powerRepository.transform);
                var bouncerNormal = bouncer.transform.up = collision.contacts[0].normal;
                bouncer.GetComponent<BouncerScript>().wallNormal = bouncerNormal;
                Destroy(gameObject);
                Debug.DrawLine(collision.contacts[0].point, collision.contacts[0].point + collision.contacts[0].normal, Color.magenta, 5f);
            }
        }
    }
}
