using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnDamage
{
    void ActivateWhenDamaged(float dmgAmt, Transform myTransform);
}
