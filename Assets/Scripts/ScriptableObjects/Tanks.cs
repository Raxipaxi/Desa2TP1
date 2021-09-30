using UnityEngine;

[CreateAssetMenu(fileName = "New Tank", menuName = "Tank")]
public class Tanks : ScriptableObject
{
    #region SerializedFields
    [SerializeField]protected float _life;
    [SerializeField]protected float _speed;
    [SerializeField]protected Weapons _weapon; // Cambiar por Ammo
    #endregion

    #region Properties
    public float Life => _life;
    public float Speed => _speed;
    public Weapons Bullet => _weapon;
    #endregion
}
