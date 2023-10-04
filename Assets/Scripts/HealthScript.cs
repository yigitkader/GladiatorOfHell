using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    public void ApplyDamage(float damage){
        health -= damage;

        if(health <= 0){
            print("Character Died");
        }

    }
 













} //End Of Class
