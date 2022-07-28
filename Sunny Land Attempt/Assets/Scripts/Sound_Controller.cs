using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller : MonoBehaviour
{
    public static Sound_Controller instance;

    public AudioSource[] soundEffect;

    private void Awake()
    {
        instance = this;
    }

    public void SoundEffectUp(int whichSound)
    {
        soundEffect[whichSound].Stop();
        soundEffect[whichSound].Play();
    }
    public void MixedSoundEffectUp(int whichSound)
    {
        soundEffect[whichSound].Stop();
        soundEffect[whichSound].pitch = Random.Range(0.8f,1.3f);

        soundEffect[whichSound].Play();
    }
}
