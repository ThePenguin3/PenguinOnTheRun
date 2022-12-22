using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    

    public AudioClip sound1ATK,sound2TAKEDMG,sound3DIE,sound4MOVE;
    AudioSource audioSorc;
    public AudioSource audioSorcLESSVOL;

    void Start()
    {
        audioSorc = GetComponent<AudioSource>();
    }
    

    public void CallSound1ATK()
    {
        audioSorc.PlayOneShot(sound1ATK);
    }
    public void CallSound2TAKEDMG()
    {
        audioSorc.PlayOneShot(sound2TAKEDMG);
    }

    public void CallSound3DIE()
    {
        audioSorc.PlayOneShot(sound3DIE);
    }

    public void CallSound4WALK()
    {
        audioSorc.PlayOneShot(sound4MOVE);
    }





    public void CallLESSSound1ATK()
    {
        audioSorcLESSVOL.PlayOneShot(sound1ATK);
    }
    public void CallLESSSound2TAKEDMG()
    {
        audioSorcLESSVOL.PlayOneShot(sound2TAKEDMG);
    }

    public void CallLESSSound3DIE()
    {
        audioSorcLESSVOL.PlayOneShot(sound3DIE);
    }

    public void CallLESSSound4WALK()
    {
        audioSorcLESSVOL.PlayOneShot(sound4MOVE);
    }
}
