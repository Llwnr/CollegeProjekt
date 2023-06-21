using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomOnDeath : MonoBehaviour
{
    [SerializeField]private GameObject activateBoom;


    private void OnDisable() {
        Instantiate(activateBoom, transform.position, Quaternion.identity);
    }
}
