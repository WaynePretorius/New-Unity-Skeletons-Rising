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
        BroadcastMessage(Tags.METHOD_DAMAGETAKEN);
        
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            EnemyDies();
        }

    }

    //Destroys the GameObject
    public void EnemyDies()
    {
        Animator myAnim = GetComponent<Animator>();
        myAnim.SetBool(Tags.ANIM_DYING, true);
        Destroy(gameObject,1f);
    }
}
