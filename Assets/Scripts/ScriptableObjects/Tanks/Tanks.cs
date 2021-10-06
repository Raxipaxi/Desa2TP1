using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tank")]
public class Tanks : ScriptableObject
{
    #region SerializedFields
    [SerializeField]protected int _life;
    [SerializeField]protected float _speed;
    [SerializeField]protected float _shootCd;
    [SerializeField]protected int _maxAmmo;
    [SerializeField] protected int _initAmmo;
    #endregion

    #region Properties
    public int Life => _life;
    public float Speed => _speed;
    public float ShootCd => _shootCd;
    public int MaxAmmo => _maxAmmo;
    public int InitAmmo => _initAmmo;

    #endregion
}
