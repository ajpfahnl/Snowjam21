using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource[] sounds;

    public void SetBGM(bool toggle){
        sounds[0].volume = 0;
    }

    public void SetSFX(bool toggle){
    }

}
