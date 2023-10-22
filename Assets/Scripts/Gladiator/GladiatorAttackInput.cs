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
        int attackNumber = Random.Range(1,7);
        if(attackNumber == 1){
            if(G_StandingMeleeMidAttackReady()){
                gladiatorAnimations.G_StandingMeleeMidAttack();
                characterSoundFX.SoundAttack1();
            }
        }else if(attackNumber ==2){
            if(G_StandingMelee360AttackReady()){
                gladiatorAnimations.G_StandingMelee360Attack();
                characterSoundFX.SoundAttack3();
            }
        }else if(attackNumber == 3){
            if(G_StandingMeleeBackhandAttackReady()){
                gladiatorAnimations.G_StandingMeleeBackhandAttack();
                characterSoundFX.SoundAttack1();
            }
        }else if(attackNumber == 4){
            if(G_StandingMeleeComboAttackReady()){
                gladiatorAnimations.G_StandingMeleeComboAttack();
                characterSoundFX.SoundAttack3();
            }
        }else if(attackNumber == 5){
            if(G_SwordAndShieldSlashAttackReady()){
                gladiatorAnimations.G_SwordAndShieldAttack();
                characterSoundFX.SoundAttack1();
            }
        }else if(attackNumber == 6){
            if(G_StandingMeleeDownwardAttackReady()){
                gladiatorAnimations.G_StandingMeleeDownwardAttack();
                characterSoundFX.SoundAttack3();
            }
        }
        // else if(attackNumber == 7){
        //     if(G_Standing2HMagicAttackReady()){
        //         gladiatorAnimations.G_Standing2HMagicAttack();
        //         characterSoundFX.SoundAttack2();
        //     }
        // }   

    }


    public void ActivateAttackPoint(){
        attackPoint.SetActive(true);
    }

    public void DeactivateAttackPoint(){
        if(attackPoint.activeInHierarchy){
            attackPoint.SetActive(false);
        }
    }




    private bool IsAnyAttackAnimationsRunningNow(){
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State")
        ){
          return true;  
        }

        return false;
    }

    
    // These functions is checking, is there any function running same time for attack 
    private bool G_StandingMeleeMidAttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State")
        ){
          return false;  
        }

        return true;
    }

        private bool G_StandingMelee360AttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State")
        ){
          return false;  
        }

        return true;
    }

        private bool G_StandingMeleeBackhandAttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State")
        ){
          return false;  
        }

        return true;
    }

        private bool G_StandingMeleeComboAttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State") 
        ){
          return false;  
        }

        return true;
    }

        private bool G_SwordAndShieldSlashAttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State")
        ){
          return false;  
        }

        return true;
    }


        private bool G_StandingMeleeDownwardAttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State") 
        ){
          return false;  
        }

        return true;
    }


        private bool G_Standing2HMagicAttackReady(){
        
        if( 
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Mid_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_360_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Backhand_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Combo_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_SwordAndShieldSlash_Attack_State") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_Melee_Downward_Attack_State")
            //animator.GetCurrentAnimatorStateInfo(0).IsName("G_Standing_2H_Magic_Attack_State") ||
            //animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAndShieldBlockDefendState")
        ){
          return false;  
        }

        return true;
    }




}//class end
