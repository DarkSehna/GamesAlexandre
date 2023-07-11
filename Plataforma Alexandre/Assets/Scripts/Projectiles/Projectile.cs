using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private AttackDetails attackDetails;
    private float speed;
    private float travelDistance;
    private float xStartPos;
    private float yStartPos;

    [SerializeField] private float gravity;
    [SerializeField] private float damageRadius;

    private Rigidbody2D rb;
    private bool isGravityOn;
    private bool hasHitGround;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform damagePosition;

    public GameObject objectToSpawn;
    public GameObject powerRepository;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = transform.right * speed;
        isGravityOn = false;
        xStartPos = transform.position.x;
        yStartPos = transform.position.y;
        powerRepository = GameObject.Find("AmmoRepository");
    }

    public virtual void Update()
    {
        if(!hasHitGround)
        {
            //attackDetails.position = transform.position;
            if(isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public virtual void FixedUpdate()
    {
        if(!hasHitGround)
        {
            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance || Mathf.Abs(yStartPos - transform.position.y) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }
    }

    /*private void FixedUpdate()
    {
        if(!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);
            if(damageHit)
            {
                //damageHit.transform.SendMessage("Damage", attackDetails);
                //Destroy(gameObject);
            }
            if(groundHit)
            {
                if (objectToSpawn != null)
                {
                    Instantiate(objectToSpawn, transform.position, Quaternion.identity, powerRepository.transform);
                }
                hasHitGround = true;
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
                Destroy(gameObject); // ou instantiate player tool
            }
            if(Mathf.Abs(xStartPos-transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
        }
    }*/

    public virtual void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        //attackDetails.damageAmount = damage;
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
