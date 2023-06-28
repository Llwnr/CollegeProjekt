using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnAnimEnd : MonoBehaviour
{
    public void DestroyOnAnimEnd(){
        Destroy(gameObject);
    }
}
