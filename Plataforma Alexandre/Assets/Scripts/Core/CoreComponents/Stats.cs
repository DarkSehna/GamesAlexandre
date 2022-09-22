using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponents
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxShield;
    [SerializeField] private float shieldRechargeTime;
    [SerializeField] private float shieldRechargeValue;
    [SerializeField] private float maxShieldRecharge;
    public float currentHealth;
    public float currentShield;
    private float timeWithoutDamage;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
        currentShield = maxShield;
        timeWithoutDamage = shieldRechargeTime;
    }

    #region Health
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timeWithoutDamage += Time.deltaTime;

        if(currentShield < maxShieldRecharge && timeWithoutDamage >= shieldRechargeTime)
        {
            currentShield += shieldRechargeValue * Time.deltaTime;
            if(currentShield > maxShieldRecharge)
            {
                currentShield = maxShieldRecharge;
            }
        }

        /*if(currentShield < 100)
        {
            StartCoroutine(RechargeShield());           
        }
        if (currentShield > maxShield)
        {
            currentShield = maxShield;
        }*/
    }

    public void DecreaseHealth(float amount)
    {
        timeWithoutDamage = 0f;

        if(currentShield > 0)
        {
            currentShield -= amount;
            
            if(currentShield <= 0)
            { 
                Debug.Log("Shield broken ");
                currentShield = 0;
            }
        }
        else
        {
            currentHealth -= amount;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Health is zero!!");
            //Eventually here is where the entity will let the system know that it has died and the system will respond appropriately.
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    private IEnumerator RechargeShield()
    {
        yield return new WaitForSeconds(shieldRechargeTime);
        //currentShield = maxShield/2;
        currentShield += 1;
    }

    public void WaterRespawn()
    {
        core.entity.transform.position = core.PlayerRespawn.GetRespawnPosition();
    }
    #endregion
}
