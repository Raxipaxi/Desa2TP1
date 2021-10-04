using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tank")]
public class Tanks : ScriptableObject
{
    #region SerializedFields
    [SerializeField]protected float _life;
    [SerializeField]protected float _speed;
    [SerializeField]protected float _shootCd; // Cooldown
    #endregion

    #region Properties
    public float Life => _life;
    public float Speed => _speed;
    public float ShootCd => _shootCd;
    #endregion
}
