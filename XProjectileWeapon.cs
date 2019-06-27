using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface XProjectileWeapon 
{
    Transform ProjectileSpawn { get; set; }
    void CastProjectile();
}
