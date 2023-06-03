using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomOnDeath : MonoBehaviour
{
    [SerializeField]private ParticleSystem activateBoom;
    private ParticleSystem newParticle;
    private void Awake() {
        newParticle = Instantiate(activateBoom, transform.position, Quaternion.identity);
        newParticle.Stop();
    }
    private void OnDestroy() {
        if(!newParticle) return;
        newParticle.gameObject.transform.position = transform.position;
        newParticle.Play();
    }
}
