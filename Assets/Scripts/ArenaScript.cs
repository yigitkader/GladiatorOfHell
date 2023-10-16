using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{

    private Vector3 stopPoint = new Vector3(0,50,-40);

    public bool sceneDone;

    private Camera arenaCamera;
    
    void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 newPosition = new Vector3(0, arenaCamera.transform.position.y-1, -40);
        
        // if(newPosition.y >= stopPoint.y){
        //     arenaCamera.transform.position = arenaCamera.transform.position - Vector3.up * 10 * Time.deltaTime;        
        // }else{
        //     sceneDone = true;
        //     arenaCamera.enabled = false;
        //     Camera.main.enabled = true;
        // }
    }

}
