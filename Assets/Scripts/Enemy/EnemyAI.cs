using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    //variables Declared at the start

    //referenced Chaches declared
    [Header("Enemy Ai Settings")]
    [SerializeField] private Transform target;

    NavMeshAgent navAgent;

    // Start is called before anything else
    void Awake  ()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    //Function that sets the destination of the AI
    private void SetDestination()
    {
        navAgent.SetDestination(target.position);
    }
}
