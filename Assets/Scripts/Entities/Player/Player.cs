using UnityEngine;
using System;

public class Player : Actor
{

    #region Properties

    [SerializeField] private Transform _canon;

    private Transform _transform; 
    private Rigidbody _rb;
    
    public Tanks _tank;
    private float _nextFire;
    public AmmoManager _ammo;
    public MissileFactory _ammoFactory;
    
    
    #endregion

    #region MyRegion
    public event Action<int> OnDamageReceived;
    public event Action OnDie;
    
    #endregion
    

    #region Unity Methods

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _ammo = new AmmoManager(_tank.MaxAmmo, _tank.InitAmmo);
    }

    private void Start()
    {
        _nextFire = 0;
        _transform = transform;
    }
    #endregion
    
    #region Mobile methods
    public override void Move(Vector3 dir, float speed)
    {
        dir *= speed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
    }

    public void LookAt(Vector3 dir)
    {
        _transform.forward = dir.normalized;
    }
    public void Attack()
    {
        if (Time.time > _nextFire && !_ammo.GetIsEmpty())
        {
            _ammoFactory.Create(MissilesID.PlayerMiss, _canon,Quaternion.Euler(_canon.forward));
            _nextFire = Time.time + _tank.ShootCd;
        }
    }

    public override void Idle()
    {
        _rb.velocity = Vector3.zero;
    }

    #endregion

    #region Damageable
    
    public override void TakeDamage(int damage)
    {
        _life -= damage;
        OnDamageReceived?.Invoke(damage);
        if(CurrentLife<=0) Die();
    }

    public override void Die()
    {
        OnDie?.Invoke();
        Destroy(this);
    }
    #endregion    

    public float GetSpeed()
    {
        return _tank.Speed;
    }

    public AmmoManager GetAmmoM()
    {
        return _ammo;
    }
}
