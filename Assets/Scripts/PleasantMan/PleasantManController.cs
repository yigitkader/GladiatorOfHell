using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PleasantManState{
    CHASE,
    ATTACK
}
public class PleasantManController : MonoBehaviour{
    
    private PleasantManAnimations pleasantManAnimations;
    private NavMeshAgent navMeshAgent;

    private Transform gladiatorTarget;

    [SerializeField]
    private float movementSpeed =  PleasantManModel.MOVEMENT_SPEED;

    [SerializeField]
    private float attackDistance = PleasantManModel.ATTACK_DISTANCE;

    [SerializeField]
    private float chaseGladiatorAfterAttackDistance = PleasantManModel.CHASE_GLADIATOR_AFTER_ATTACK_DISTANCE;

    [SerializeField]
    private float waitBeforeAttackTime = PleasantManModel.WAIT_BEFORE_ATTACK_TIME;

    private float attackTimer ;


    private PleasantManState pleasantManState;


    public GameObject attackPoint;

    private void Awake() {
        pleasantManAnimations = GetComponent<PleasantManAnimations>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        gladiatorTarget = GameObject.FindGameObjectWithTag(Tags.GLADIATOR_TAG).transform;
    }

    private void Start() {
        pleasantManState = PleasantManState.CHASE;

        attackTimer = waitBeforeAttackTime;
    }

    private void Update() {

        if(pleasantManState == PleasantManState.CHASE){
            ChaseGladiator();
        }

        if(pleasantManState == PleasantManState.ATTACK){
            AttackToGladiator();
        }
        
    }


    private void ChaseGladiator(){
        navMeshAgent.SetDestination(gladiatorTarget.position);
        navMeshAgent.speed = movementSpeed;

        if(navMeshAgent.velocity.sqrMagnitude == 0){
            pleasantManAnimations.Run(false);
        }else{
            pleasantManAnimations.Run(true);
        }


        if(Vector3.Distance(transform.position,gladiatorTarget.position) <= attackDistance){
            pleasantManState = PleasantManState.ATTACK;
        }
    }

    private void AttackToGladiator(){
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;
        pleasantManAnimations.Run(false);

        attackTimer += Time.deltaTime;
        if(attackTimer > waitBeforeAttackTime){
            pleasantManAnimations.RandomAttack();
            attackTimer = 0f;
        }

        if(Vector3.Distance(transform.position, gladiatorTarget.position) > attackDistance + chaseGladiatorAfterAttackDistance){
            navMeshAgent.isStopped = false;
            pleasantManState = PleasantManState.CHASE;
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
