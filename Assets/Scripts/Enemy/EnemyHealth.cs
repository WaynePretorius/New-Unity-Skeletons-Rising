using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //variables for the enemy health
    [Header("Enemy Health Settings")]
    [SerializeField] private float enemyHealth = 100f;

    //deducts the hitpoints of the GameObject
    public void DeductHealth(float damage)
    {
            enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            EnemyDies();
        }

    }

    //Destroys the GameObject
    public void EnemyDies()
    {
        Destroy(gameObject);
    }
}
