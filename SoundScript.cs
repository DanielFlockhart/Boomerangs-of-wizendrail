using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
