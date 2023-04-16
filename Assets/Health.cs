using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100.0f; // The maximum health of the object
    public float currentHealth = 100.0f; // The current health of the object

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // Destroy the object when it dies
        Destroy(gameObject);
    }

    private void Update()
    {
        Debug.Log(currentHealth);
    }
}
