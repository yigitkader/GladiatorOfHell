using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;


public class MainMenuScript : MonoBehaviour
{

    async public void PlayLevel1(){ 
        
        SceneManager.LoadSceneAsync(2);

   }

}
