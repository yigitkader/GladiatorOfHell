using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour{

    private AudioSource soundFX;

    [SerializeField]
    private AudioClip attackSound1,attackSound2,attackSound3,attackSound4,dieSound;

    private void Awake() {
        soundFX = GetComponent<AudioSource>();
    }


    public void SoundAttack1(){
        soundFX.clip = attackSound1;
        soundFX.Play();
    }

    public void SoundAttack2(){
        soundFX.clip = attackSound2;
        soundFX.Play();
    }

    public void SoundAttack3(){
        soundFX.clip = attackSound3;
        soundFX.Play();
    }
    
    public void SoundAttack4(){
        soundFX.clip = attackSound4;
        soundFX.Play();
    }

    public void SoundDie(){
        soundFX.clip = dieSound;
        soundFX.Play();
    }
}
