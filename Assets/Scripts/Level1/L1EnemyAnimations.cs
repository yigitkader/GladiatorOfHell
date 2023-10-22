using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1EnemyAnimations : MonoBehaviour
{
   
    private Animator animator;

    private CharacterSoundFX characterSoundFX;


    private void Awake() {
        animator = GetComponent<Animator>();
        characterSoundFX = GetComponentInChildren<CharacterSoundFX>();

    }


    public void Run(bool run){
        animator.SetBool(AnimationTags.SLOW_RUN_ANIMATION_STATE,run);    
    }

    
    private void Attack1(){
        animator.SetTrigger(AnimationTags.ATTACK_1_STATE);
    }

    private void Attack2(){
        animator.SetTrigger(AnimationTags.ATTACK_2_STATE);
    }

    private void Attack3(){
        animator.SetTrigger(AnimationTags.ATTACK_3_STATE);
    }

    private void Attack4(){
        animator.SetTrigger(AnimationTags.ATTACK_4_STATE);
    }


    public void DamageHitReaction(){
        animator.SetTrigger(AnimationTags.DAMAGE_HIT_REACTION_STATE);
    }



    public void RandomAttack(){
        int attackNumber = Random.Range(0,4);
        if(attackNumber == 0){
            characterSoundFX.SoundAttack1();
            Attack1();
        }else if(attackNumber == 1){
            characterSoundFX.SoundAttack2();
            Attack2();
        }else if(attackNumber == 2){
            characterSoundFX.SoundAttack3();
            Attack3();
        }else if(attackNumber == 3){
            characterSoundFX.SoundAttack4();
            Attack4();
        }      
    }


}
