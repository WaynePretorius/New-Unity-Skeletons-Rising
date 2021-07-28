using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [Header("Player Health Settings")]
    [SerializeField] private float playerHealth = 100f;

    public void DamagePlayer(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= Mathf.Epsilon)
        {
            GetComponent<DeathHandler>().DeathScreen();
        }
    }
}


