using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class MissilePref : MissileAbstract
{
    #region Properties
    public LayerMask hittableMask;
    [SerializeField] private float _lifeTime = 3f;
    public Missiles _missile;
    
    private Collider _collider;
    private Transform _transform;
    private Rigidbody _rigidbody;
    #endregion
    
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;

        Init();
    }

    private void Init()
    {
        //Collider
        _collider.isTrigger = true;
        
        //Rigidbody
        _rigidbody.isKinematic = true;

    }
    private void Update()
    {
        _transform.position += _transform.forward * _missile.Speed * Time.deltaTime;
        _lifeTime -= Time.deltaTime;
        if (_lifeTime<=0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == hittableMask)
        { 
            other.GetComponent<Actor>()?.TakeDamage(_missile.Damage); 
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}