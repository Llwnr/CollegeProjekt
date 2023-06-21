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
        Debug.Log("MyName: " + name);
    }

    // Update is called once per frame
    void Update()
    {
        if(myParticleSystem.isPlaying){
            hasPlayed = true;
        }
        if(hasPlayed && myParticleSystem.isStopped) {
            if(transform.parent == null){
                Destroy(gameObject);
                return;
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
