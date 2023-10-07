using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorShieldScript : MonoBehaviour
{

    private L1HealthScript healthScript;


   private void Awake() {
        healthScript = GetComponent<L1HealthScript>();
   }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateShield(bool shieldActive){
        healthScript.shieldActived = shieldActive;
    }
}
