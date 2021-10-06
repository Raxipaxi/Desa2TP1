using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Missile", menuName = "Missile")]
public class Missiles : ScriptableObject
{
    #region SerializedFields
    [SerializeField]protected int _damage;
    [SerializeField]protected float _speed;
    #endregion

    #region Properties
    public int Damage => _damage;
    public float Speed => _speed;
    #endregion

}
