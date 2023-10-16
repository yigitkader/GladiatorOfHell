using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;


public class MainMenuScript : MonoBehaviour
{

    private void Awake() {
        //DontDestroyOnLoad(this.gameObject);

    }
    async public void PlayLevel1(){ 
        
        SceneManager.LoadSceneAsync(1);

   }

}
