using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    private float xDeathDegree = -90f;

    private float deathSmooth = 0.9f;

    private float rotateTime = 0.23f;

    private bool playerDied;

    public bool isPlayer;


    private void Update() {
        if(playerDied){
            // Can switch with animation
            RotateAfterDeath();
        }
    }

    public void ApplyDamage(float damage){
        health -= damage;

        if(health <= 0){
            GetComponent<Animator>().enabled = false;

            StartCoroutine(AllowRotate());

            if(isPlayer){
                GetComponent<GladiatorMoveScript>().enabled = false;
                GetComponent<GladiatorAttackInput>().enabled = false;
            }else{

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













} //End Of Class
