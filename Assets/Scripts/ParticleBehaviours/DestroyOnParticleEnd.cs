using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnParticleEnd : MonoBehaviour
{
    private ParticleSystem myParticleSystem;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myParticleSystem.isPlaying){
            hasPlayed = true;
        }
        if(hasPlayed && myParticleSystem.isStopped) Destroy(gameObject);
    }
}
