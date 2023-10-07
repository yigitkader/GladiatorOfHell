using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{
    CHASE,
    ATTACK
}
public class L1EnemyController : MonoBehaviour{
    
    private L1EnemyAnimations enemyAnimations;
    private NavMeshAgent navMeshAgent;

    private Transform gladiatorTarget;

    [SerializeField]
    private float movementSpeed =  L1EnemyModel.MOVEMENT_SPEED;

    [SerializeField]
    private float attackDistance = L1EnemyModel.ATTACK_DISTANCE;

    [SerializeField]
    private float chaseGladiatorAfterAttackDistance = L1EnemyModel.CHASE_GLADIATOR_AFTER_ATTACK_DISTANCE;

    [SerializeField]
    private float waitBeforeAttackTime = L1EnemyModel.WAIT_BEFORE_ATTACK_TIME;

    private float attackTimer ;


    private EnemyState enemyState;


    public GameObject attackPoint;



    private void Awake() {
        enemyAnimations = GetComponent<L1EnemyAnimations>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        gladiatorTarget = GameObject.FindGameObjectWithTag(Tags.GLADIATOR_TAG).transform;
    }

    private void Start() {
        enemyState = EnemyState.CHASE;

        attackTimer = waitBeforeAttackTime;
    }

    private void Update() {

        if(enemyState == EnemyState.CHASE){
            ChaseGladiator();
        }

        if(enemyState == EnemyState.ATTACK){
            AttackToGladiator();
        }
        
    }


    private void ChaseGladiator(){
        navMeshAgent.SetDestination(gladiatorTarget.position);
        navMeshAgent.speed = movementSpeed;

        if(navMeshAgent.velocity.sqrMagnitude == 0){
            enemyAnimations.Run(false);
        }else{
            enemyAnimations.Run(true);
        }


        if(Vector3.Distance(transform.position,gladiatorTarget.position) <= attackDistance){
            enemyState = EnemyState.ATTACK;
        }
    }

    private void AttackToGladiator(){
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        enemyAnimations.Run(false);

        attackTimer += Time.deltaTime;
        if(attackTimer > waitBeforeAttackTime){
            enemyAnimations.RandomAttack();
            attackTimer = 0f;
        }

        if(Vector3.Distance(transform.position, gladiatorTarget.position) > attackDistance + chaseGladiatorAfterAttackDistance){
            navMeshAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }

    }


    public void ActivateAttackPoint(){
        attackPoint.SetActive(true);
    }

    public void DeactivateAttackPoint(){
        if(attackPoint.activeInHierarchy){
            attackPoint.SetActive(false);
        }
    }













} // endClass
