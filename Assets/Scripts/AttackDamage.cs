using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layerMask;
    public float radius = 1f;

    public float damage = 10f;


    private void Update() {
        Collider[] hits = Physics.OverlapSphere(transform.position,radius,layerMask);
        if(hits.Length > 0){
            hits[0].GetComponent<HealthScript>().ApplyDamage(damage);

            gameObject.SetActive(false);
        }
        
    }

}
