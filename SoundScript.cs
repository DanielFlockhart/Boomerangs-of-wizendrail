using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource fireball;
    public void Walking()
    {
        if (!walk.isPlaying)
        {
            walk.Play();
        }
        
    }
    public void fireballz()
    {
        fireball.Play();

    }
}
