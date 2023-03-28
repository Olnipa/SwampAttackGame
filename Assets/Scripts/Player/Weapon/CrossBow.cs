using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : Weapon
{
    public override void InitializeWeapon()
    {
        if (_targetIsPlayer)
            _direction = Vector2.left;
        else
            _direction = Vector2.right;
    }

    public override void Shoot(Transform shootPoint)
    {
        InstantiateBullet(shootPoint);
    }
}