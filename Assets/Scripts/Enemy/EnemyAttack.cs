using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Sword Settings")]
    [SerializeField] private float damage = 25f;

    private PlayerHealth target;

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == Tags.OBJ_PLAYER_NAME)
        {
            target.DamagePlayer(damage);
        }
    }
}
