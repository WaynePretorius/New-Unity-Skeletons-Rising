using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    //variables Declared at the start
    [Header("Enemy AI Settings")]
    [SerializeField] private float pickUpRange = 5f;

    private float distanceToTarget = Mathf.Infinity;

    //referenced Chaches declared
    [Header("Enemy Ai Caches")]
    [SerializeField] private Transform target;

    private NavMeshAgent navAgent;

    //states for the AI
    private bool isProvoked = false;

    // Start is called before anything else
    void Awake  ()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SeeIfTargetIsInRange();
    }

    //look if the player is in range of the enemy
    private void SeeIfTargetIsInRange()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= pickUpRange)
        {
            isProvoked = true;
        }
    }
    
    //draws the radius so that developer can see where the range is for the ai script
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }

    //enemy engages the player(target)
    private void EngageTarget()
    {
        if (distanceToTarget >= navAgent.stoppingDistance)
        {
            SetDestination();
        }

        if (distanceToTarget <= navAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    //Sets the Ai of the enemy to go to the player if the conditions is met
    private void SetDestination()
    {
        navAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        print("I am attacking");
    }
}
