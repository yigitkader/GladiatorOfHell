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

    private GameObject gladiatorTarget;

    private GameObject enemyTarget;

    private void Awake() {
        characterSoundFX = GetComponentInChildren<CharacterSoundFX>();

        gladiatorAnimations = GameObject.FindGameObjectWithTag(Tags.GLADIATOR_TAG).GetComponent<GladiatorAnimations>();
        enemyAnimations = GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG_LEVEL1).GetComponent<L1EnemyAnimations>();

        gladiatorTarget = GameObject.FindGameObjectWithTag(Tags.GLADIATOR_TAG);
        enemyTarget = GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG_LEVEL1);
    }

    private void Update() {
        
        if(playerDied){
            RotateAfterDeath();
        }
    }

    public void ApplyDamage(float damage){

        if(shieldActived){
            // will change for other levels
            return;
        }

        health -= damage;

        if(health > 0){
            if(isPlayer){
                characterSoundFX.DamageHitSound1();
                gladiatorAnimations.DamageHitReaction();
            }else{
                characterSoundFX.DamageHitSound2();
                enemyAnimations.DamageHitReaction();
            }
        }

        if(healthUI != null){
            healthUI.fillAmount = health / 100f;
        }

        if(health <= 0){
            
            characterSoundFX.SoundDie();

            StartCoroutine(AllowRotate()); // Need to delete or change

            if(isPlayer){
                enemyTarget.GetComponent<Animator>().enabled = false;
                enemyTarget.GetComponent<Animator>().enabled = true;
                
                gladiatorTarget.GetComponent<GladiatorMoveScript>().enabled = false;
                gladiatorTarget.GetComponent<GladiatorAttackInput>().enabled = false;

                Camera.main.transform.SetParent(null);
                
                
                enemyTarget.GetComponent<L1EnemyController>().enabled = false;
                enemyTarget.GetComponent<NavMeshAgent>().enabled =false;    
            
                enemyAnimations.Victory();
                gladiatorTarget.GetComponent<Animator>().enabled = false;
                //StartCoroutine(StopGladiatorAnimation(gladiatorTarget,3f));
                
            }else{
                gladiatorTarget.GetComponent<Animator>().enabled = false;
                gladiatorTarget.GetComponent<Animator>().enabled = true;

                enemyTarget.GetComponent<L1EnemyController>().enabled = false;
                enemyTarget.GetComponent<NavMeshAgent>().enabled =false;    

                                
                gladiatorTarget.GetComponent<GladiatorMoveScript>().enabled = false;
                gladiatorTarget.GetComponent<GladiatorAttackInput>().enabled = false;
                gladiatorAnimations.Victory();

                enemyTarget.GetComponent<Animator>().enabled = false;
            }
        }

    }


    IEnumerator StopEnemyAnimation(GameObject enemyTarget,float delay){
        
        yield return new WaitForSeconds(delay);
        enemyTarget.GetComponent<Animator>().enabled = false;
    }


    IEnumerator StopGladiatorAnimation(GameObject gladiatorTarget,float delay){
        
        yield return new WaitForSeconds(delay);
        gladiatorTarget.GetComponent<Animator>().enabled = false;
    }



    IEnumerator AllowRotate(){
        playerDied = true;
        yield return new WaitForSeconds(rotateTime);
        playerDied = false;
    }


    private void RotateAfterDeath(){
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x,xDeathDegree,Time.deltaTime * deathSmooth),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }












} //End Of Class
