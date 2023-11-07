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

    private GameObject gladiator;

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

    private Vector3 stopPoint = new Vector3(0,50,-40);

    private GameObject mainCamera;

    private GameObject arenaCamera;

    private bool uncutSceneDone;

    private GameObject healthUICanvas;

    private GameObject touchUI;



    private void Awake() {
        enemyAnimations = GetComponent<L1EnemyAnimations>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        gladiator = GameObject.FindGameObjectWithTag(Tags.GLADIATOR_TAG);
        gladiatorTarget = gladiator.transform;
    
        touchUI = GameObject.FindGameObjectWithTag("TouchUI");
        touchUI.SetActive(false);

        //Load Uncut Scene
        navMeshAgent.enabled = false;
        arenaCamera = GameObject.FindGameObjectWithTag("ArenaCamera");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.SetActive(false);
        arenaCamera.SetActive(true);
        healthUICanvas = GameObject.FindGameObjectWithTag("HealthUICanvas");
        healthUICanvas.SetActive(false);

    }

    private void LoadUncutScene(){

    }

    private void Start() {
        enemyState = EnemyState.CHASE;

        attackTimer = waitBeforeAttackTime;
    }

    private void Update() {

        
        if(navMeshAgent.enabled){
            if(enemyState == EnemyState.CHASE){
                ChaseGladiator();
            }

            if(enemyState == EnemyState.ATTACK){
                AttackToGladiator();
            }
        }
        if(!uncutSceneDone){
            Vector3 newPosition = new Vector3(0, arenaCamera.transform.position.y-1, -40);
            
            if(newPosition.y >= stopPoint.y){
                arenaCamera.transform.position = arenaCamera.transform.position - Vector3.up * 10 * Time.deltaTime;        
            }else{
                uncutSceneDone = true;
                mainCamera.SetActive(true);
                arenaCamera.SetActive(false);
                navMeshAgent.enabled = true;
                healthUICanvas.SetActive(true);
                touchUI.SetActive(true);
            }
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
