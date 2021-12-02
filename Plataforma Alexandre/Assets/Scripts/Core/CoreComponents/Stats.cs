using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponents
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;
    }

    #region Health
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

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
    #endregion
}
