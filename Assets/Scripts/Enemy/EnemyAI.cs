using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    //variables Declared at the start
    [Header("Enemy AI Settings")]
    [SerializeField] private float pickUpRange = 5f;
    [SerializeField] private float lookRotationSpeed = 2f;

    private float distanceToTarget = Mathf.Infinity;

    //referenced Chaches declared
    private Transform target;

    private NavMeshAgent navAgent;
    private Animator myAnim;

    //states for the AI
    private bool isProvoked = false;

    // Awake is called before anything else
    void Awake  ()
    {
        navAgent = GetComponent<NavMeshAgent>();
        myAnim = GetComponent<Animator>();
    }

    //method called on the first frame it is instantiated
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        SeeIfTargetIsInRange();
    }

    //look if the player is in range of the enemy
    private void SeeIfTargetIsInRange()
    {
        if (target == null) { return; }
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

        if(target == null) 
        {
            myAnim.Play(Tags.ANIM_IDLE);
            return;
        }

        LookAtTarget();

        if (distanceToTarget >= navAgent.stoppingDistance)
        {
            SetDestination();
            AttackTarget(false);
        }

        if (distanceToTarget <= navAgent.stoppingDistance)
        {
            AttackTarget(true);
        }
        
    }

    //the AI looks at the target, rotates the AI so that it always looks at the player/target, in order to actually hit them
    private void LookAtTarget()
    {
        Vector3 distance = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lookRotationSpeed);
    }

    //Sets the Ai of the enemy to go to the player if the conditions is met
    private void SetDestination()
    {
        navAgent.SetDestination(target.position);
        myAnim.SetBool(Tags.ANIM_WALK, isProvoked);
    }

    //lets they AI attack the target
    private void AttackTarget(bool isAttacking)
    {
        print("I am attacking");
        myAnim.SetBool(Tags.ANIM_ATTACK, isAttacking);
    }

    //let the AI chase the target if it was shot at
    public void DamageTakenWhileStationary()
    {
        isProvoked = true;
    }
}
