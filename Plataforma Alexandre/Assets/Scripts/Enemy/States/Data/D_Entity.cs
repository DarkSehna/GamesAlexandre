﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Data", menuName = "Data / Entity Data / Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxHealth = 30;
    public float damageHopSpeed = 3;
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;
    public float minAgroDistance = 3;
    public float maxAgroDistance = 4;
    public float stunResistance = 3;
    public float stunRecoveryTime = 2;
    public float closeRangeActionDistance = 1;
    public GameObject hitParticle;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}