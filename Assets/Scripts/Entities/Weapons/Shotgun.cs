using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    public override void Attack()
    {
        Debug.Log("Shoot");
        for (int i = 0; i < _weaponStats.FireRate; i++)
        {
           BulletPref b =  Instantiate(_weaponStats.Bullet, transform.position + Random.insideUnitSphere * 1,Quaternion.identity);
           b.SetOwner(this);
        }
        
        
    }
} 
