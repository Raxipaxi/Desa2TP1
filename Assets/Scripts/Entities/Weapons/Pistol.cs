using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    
    public override void Attack()
    {
        Debug.Log(transform.position);
        BulletPref b =  Instantiate(_weaponStats.Bullet, transform.position ,Quaternion.identity);
        b.SetOwner(this);
    }

    public override void Reload()
    {
        base.Reload();
    }
}
