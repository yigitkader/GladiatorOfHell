using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorAttackInput : MonoBehaviour
{


    private GladiatorAnimations gladiatorAnimations;

    public GameObject attackPoint;

    private GladiatorShieldScript gladiatorShieldScript;

    private CharacterSoundFX characterSoundFX;

    private Animator animator;

    void Awake()
    {
        gladiatorAnimations = GetComponent<GladiatorAnimations>();       
        gladiatorShieldScript = GetComponent<GladiatorShieldScript>();
        characterSoundFX = GetComponentInChildren<CharacterSoundFX>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.J)){
            gladiatorAnimations.SwordAndShieldBlockDefense(true);
            gladiatorShieldScript.ActivateShield(true);
        }

        if(Input.GetKeyUp(KeyCode.J)){
            gladiatorAnimations.SwordAndShieldBlockDefense(false);
            gladiatorShieldScript.ActivateShield(false);
        }

        if(Input.GetKeyDown(KeyCode.K)){
            RandomAttack();
        }

        if(Input.GetKeyUp(KeyCode.K)){
            
        }
        
    }



    public void RandomAttack(){
        int attackNumber = Random.Range(0,3);
        if(attackNumber == 0){
            if(G_StandingMeleeMidAttackReady()){
                gladiatorAnimations.G_StandingMeleeMidAttack();
                characterSoundFX.SoundAttack1();
            }
        }else if(attackNumber == 1){
            if(G_Standing_2H_Magic_Attack_State()){
                gladiatorAnimations.G_Standing2HMagicAttack();
                characterSoundFX.SoundAttack2();
            }
        }else if(attackNumber == 2){
            if(G_Standing_Melee_360_Attack_State()){
                gladiatorAnimations.G_StandingMelee360Attack();
                characterSoundFX.SoundAttack3();
            }
            
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



    private bool G_StandingMeleeMidAttackReady(){
        
        if( animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAndShieldBlockDefendState")
        ){
          return false;  
        }

        return true;
    }

    private bool G_Standing_2H_Magic_Attack_State(){
        
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAndShieldBlockDefendState")
        ){
          return false;  
        }

        return true;
    }

    private bool G_Standing_Melee_360_Attack_State(){
        
        if( animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAndShieldBlockDefendState")
        ){
          return false;  
        }

        return true;
    }

}//class end
