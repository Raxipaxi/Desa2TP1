using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Missile", menuName = "Missile")]
public class Missiles : ScriptableObject
{
    #region SerializedFields
    [SerializeField]protected float _damage;
    [SerializeField]protected float _speed;
    [SerializeField]protected MissilePref _missilePrefab;
    #endregion

    #region Properties
    public float Damage => _damage;
    public float Speed => _speed;
    public MissilePref Missile => _missilePrefab;
    #endregion

}
