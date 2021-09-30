using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iWeapon
{
    #region Properties
    Weapons Weapon { get; }
    int CurrentAmmo { get; }
    float CurrDmg { get; }
    #endregion
    
    #region Methods
    void Attack();
    void Reload();
    void AddMagazine(int _newMag);
    void SetActualDmg(float _damage);
    void SetElement(string _element);
    #endregion





}
