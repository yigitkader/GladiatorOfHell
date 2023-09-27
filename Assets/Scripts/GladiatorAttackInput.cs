using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorAttackInput : MonoBehaviour
{


    private GladiatorAnimations gladiatorAnimations;


    void Awake()
    {
        gladiatorAnimations = GetComponent<GladiatorAnimations>();       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.J)){
            gladiatorAnimations.SwordAndShieldBlockDefense(true);
        }

        if(Input.GetKeyUp(KeyCode.J)){
            gladiatorAnimations.SwordAndShieldBlockDefense(false);
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
            gladiatorAnimations.G_StandingMeleeMidAttack();
        }else if(attackNumber == 1){
            gladiatorAnimations.G_Standing2HMagicAttack();
        }else if(attackNumber == 2){
            gladiatorAnimations.G_StandingMelee360Attack();
        }   

    }




}//class end
