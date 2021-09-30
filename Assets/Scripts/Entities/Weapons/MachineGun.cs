using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MachineGun : Gun
{
    public override void Attack()
    {
        for (int i = 0; i < _weaponStats.FireRate; i++)
        {
            BulletPref b =  Instantiate(_weaponStats.Bullet, transform.position - Vector3.forward * (i/3),Quaternion.identity);
            b.SetOwner(this);
        }
    }
}
