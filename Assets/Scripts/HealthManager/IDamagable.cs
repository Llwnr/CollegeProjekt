using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void DealDamage(float dmgAmt, Transform projectile);
}
