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
        animator.SetBool(AnimationTags.SWORD_AND_SHIELD_BLOCK_DEFEND_STATE,defense);
    }


    public void G_StandingMeleeMidAttack(){
        animator.SetTrigger(AnimationTags.G_STANDING_MELEE_MID_ATTACK_STATE);
    }

    public void G_Standing2HMagicAttack(){
        animator.SetTrigger(AnimationTags.G_STANDING_2H_MAGIC_ATTACK_STATE);
    }

    public void G_StandingMelee360Attack(){
        animator.SetTrigger(AnimationTags.G_STANDING_MELEE_360_ATTACK_STATE);
    }

    
}
