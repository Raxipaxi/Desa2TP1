using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Gun : MonoBehaviour, iWeapon
{
    [SerializeField] protected Weapons _weaponStats;
    public Weapons Weapon => _weaponStats;
    public int CurrentAmmo => _weaponStats.MagazineSize;
    public float CurrDmg => _weaponStats.Damage;

    public virtual void Attack()
    {

    }

    public virtual void Reload()
    {
        Debug.Log("Reloading");
    }

    public virtual void AddMagazine(int _newMag)
    {
        throw new System.NotImplementedException();
    }

    public void SetActualDmg(float _damage)
    {
        throw new System.NotImplementedException();
    }

    public void SetElement(string _element)
    {
        throw new System.NotImplementedException();
    }
}
