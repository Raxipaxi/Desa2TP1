using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject
{
    #region SerializedFields
    [SerializeField]protected float _damage;
    [SerializeField]protected float _fireRate;
    [SerializeField]protected int _magazineSize;
    [SerializeField]protected int _ammo;
    [SerializeField]protected BulletPref _bulletPref;
    #endregion

    #region Properties
    public float Damage => _damage;
    public float FireRate => _fireRate;
    public int MagazineSize => _magazineSize;
    public int Ammo => _ammo;
    public BulletPref Bullet => _bulletPref;
    #endregion

}
