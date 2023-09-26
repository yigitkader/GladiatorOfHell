using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorAnimations : MonoBehaviour
{

    private Animator animator;




    private void Awake() {
        animator = GetComponent<Animator>();
    }



    public void Run(bool run){
        animator.SetBool(AnimationTags.SLOW_RUN_ANIMATION_STATE,run);    
    }

    public void WalkBack(bool walkBack){
        animator.SetBool(AnimationTags.WALK_BACK_ANIMATION_STATE,walkBack);    
    }


    public void SwordAndShieldBlockDefense(bool defense){
        animator.SetBool(AnimationTags.SWORD_AND_SHIELD_BLOCK_DEFENSE_STATE,defense);
    }


    public void StandingAttack(){
        animator.SetTrigger(AnimationTags.STANDING_ATTACT_ANIMATION_STATE);
    }

    public void MutantPunchAttack(){
        animator.SetTrigger(AnimationTags.MUTANT_PUNCH_ATTACK_ANIMATION_STATE);
    }

    public void JumpAttack(){
        animator.SetTrigger(AnimationTags.JUMP_ATTACK_ANIMATION_STATE);
    }


    public void randomAttack(){

        int attackNumber = Random.Range(0,3);

        if(attackNumber == 0){
            StandingAttack();
        }else if(attackNumber == 1){
            MutantPunchAttack();
        }else if(attackNumber ==2){
            JumpAttack();
        }   
    }


    
}
