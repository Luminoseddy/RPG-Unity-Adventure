using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SOURCE: 11:00 https://www.youtube.com/watch?v=hyh3kKGvJQw&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=9&t=2080s

public interface XProjectileWeapon
{
    Transform ProjectileSpawn { get; set; }

    void CastProjectile();
}