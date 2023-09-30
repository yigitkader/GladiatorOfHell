using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis
{

    public const string VERTICAL_AXIS = "Vertical";
    public const string HORIZONTAL_AXIS = "Horizontal";

}


public class Tags{
    public const string GLADIATOR_TAG="Gladiator";
    public const string ENEMY_TAG="Enemy";

    public const string PLEASANT_MAN_TAG="PleasantMan";
}

public class AnimationTags{


    // Gladiator
    public const string SLOW_RUN_ANIMATION_STATE = "SlowRunAnimationState";

    public const string WALK_BACK_ANIMATION_STATE="WalkBackAnimationState";

    public const string G_STANDING_MELEE_MID_ATTACK_STATE="G_Standing_Melee_Mid_Attack_State";

    public const string G_STANDING_2H_MAGIC_ATTACK_STATE="G_Standing_2H_Magic_Attack_State";

    public const string G_STANDING_MELEE_360_ATTACK_STATE="G_Standing_Melee_360_Attack_State";

    public const string SWORD_AND_SHIELD_BLOCK_DEFEND_STATE="SwordAndShieldBlockDefendState";



    // Enemies

    public const string ATTACK_1_STATE = "Attack1";

    public const string ATTACK_2_STATE = "Attack2";

    public const string ATTACK_3_STATE = "Attack3";

    public const string ATTACK_4_STATE = "Attack4";

}