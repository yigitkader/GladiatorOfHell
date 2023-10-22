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

    public void G_StandingMeleeBackhandAttack(){
        animator.SetTrigger(AnimationTags.G_STANDING_MELEE_BACKHAND_ATTACK_STATE);
    }

    public void G_StandingMeleeComboAttack(){
        animator.SetTrigger(AnimationTags.G_STANDING_MELEE_COMBO_ATTACK_STATE);
    }

    public void G_SwordAndShieldAttack(){
        animator.SetTrigger(AnimationTags.G_SWORDANDSHIELDSLASH_ATTACK_STATE);
    }
    
    public void G_StandingMeleeDownwardAttack(){
        animator.SetTrigger(AnimationTags.G_STANDING_MELEE_DOWNWARD_ATTACK_STATE);
    }

    public void DamageHitReaction(){
        animator.SetTrigger(AnimationTags.DAMAGE_HIT_REACTION_STATE);
    }

    public void Victory(){
        animator.SetTrigger(AnimationTags.VICTORY_STATE);
    }
}
