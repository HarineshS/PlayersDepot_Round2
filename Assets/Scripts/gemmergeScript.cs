using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemmergeScript : MonoBehaviour
{
    
    public ParticleSystem StarParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playeffect()
    {
        StarParticles.Play();
        Debug.Log("Playing Particle System...");

    }
}
