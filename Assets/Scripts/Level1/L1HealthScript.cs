using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class L1HealthScript : MonoBehaviour
{

    public float health = 100f;

    private float xDeathDegree = -90f;

    private float deathSmooth = 0.9f;

    private float rotateTime = 0.23f;

    private bool playerDied;

    public bool isPlayer;

    [SerializeField]
    public Image healthUI;

    [HideInInspector]
    public bool shieldActived;

    private CharacterSoundFX characterSoundFX;

    private GladiatorAnimations gladiatorAnimations;

    private L1EnemyAnimations enemyAnimations;


    private void Awake() {
        characterSoundFX = GetComponentInChildren<CharacterSoundFX>();

        gladiatorAnimations = GameObject.FindGameObjectWithTag(Tags.GLADIATOR_TAG).GetComponent<GladiatorAnimations>();
        enemyAnimations = GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG_LEVEL1).GetComponent<L1EnemyAnimations>();
    }

    private void Update() {
        if(playerDied){
            // Can switch with animation
            RotateAfterDeath();
        }
    }

    public void ApplyDamage(float damage){

        if(shieldActived){
            // will change for other levels
            return;
        }

        if(isPlayer){
            characterSoundFX.DamageHitSound1();
            gladiatorAnimations.DamageHitReaction();
        }else{
            characterSoundFX.DamageHitSound2();
            enemyAnimations.DamageHitReaction();
        }

        health -= damage;

        if(healthUI != null){
            healthUI.fillAmount = health / 100f;
        }

        if(health <= 0){
            
            characterSoundFX.SoundDie();

            GetComponent<Animator>().enabled = false;

            StartCoroutine(AllowRotate());

            if(isPlayer){
                
                GetComponent<GladiatorMoveScript>().enabled = false;
                GetComponent<GladiatorAttackInput>().enabled = false;

                Camera.main.transform.SetParent(null);
                
                //Stop Enemy
                var enemyTarget = GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG_LEVEL1);
                enemyTarget.GetComponent<L1EnemyController>().enabled = false;
                enemyTarget.GetComponent<NavMeshAgent>().enabled =false;

            }else{
                GetComponent<L1EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled =false;
            }
        }

    }
 

    private void RotateAfterDeath(){
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x,xDeathDegree,Time.deltaTime * deathSmooth),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }


    IEnumerator AllowRotate(){
        playerDied = true;
        yield return new WaitForSeconds(rotateTime);
        playerDied = false;
    }


    private void StopEnemy(){
        GetComponent<L1EnemyController>().enabled = false;
        GetComponent<NavMeshAgent>().enabled =false;
    }

    private void StopGladiator(){
        GetComponent<GladiatorMoveScript>().enabled = false;
        GetComponent<GladiatorAttackInput>().enabled = false;

        Camera.main.transform.SetParent(null);
    }













} //End Of Class
