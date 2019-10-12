using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileWeapon
{
    /* SpawnPoint where the projectile will appear from. */
    Transform ProjectileSpawn { get; set; }

    void CastProjectile();
}