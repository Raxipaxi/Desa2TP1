using UnityEngine;

public class Player : Actor
{
    #region Properties
   
    private Transform _transform; 
    private Rigidbody _rb;
    
    public Tanks _tank;
    private float _nextFire;

    #endregion


   

    #region Unity Methods

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
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
        if (Time.time > _nextFire)
        {
            Debug.Log("pew pew");
            _nextFire = Time.time + _tank.ShootCd;
        }
    }

    public override void Idle()
    {
        _rb.velocity = Vector3.zero;
    }

    #endregion

        

    public float GetSpeed()
    {
        return _tank.Speed;
    }

    
}
