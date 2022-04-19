using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponents
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxShield;
    [SerializeField] private float shieldRechargeTime;
    private float currentHealth;
    private float currentShield;
    

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
        currentShield = maxShield;
    }

    #region Health
    public void DecreaseHealth(float amount)
    {
        if(currentShield > 0)
        {
            currentShield -= amount;
            
            if(currentShield <= 0)
            {
                Debug.Log("Shield broken ");
                //core.entity.transform.position = core.playerRespawn.GetRespawnPosition();
                StartCoroutine(RechargeShield());
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
        currentShield = maxShield;
    }
    #endregion
}
