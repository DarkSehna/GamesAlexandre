using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float spd;
    Rigidbody rig;
    private void Start()
    {
       rig = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 position = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
       rig.velocity = position * spd;
    }
}
