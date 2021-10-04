using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class MissilePref : MonoBehaviour
{
    #region Properties
   private LayerMask hittableMask;
    [SerializeField] private float _lifeTime = 3f;
    public Missiles _missile;
    
    private Collider _collider;
    private Rigidbody _rigidbody;
    #endregion
    
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        Init();
    }

    private void Init()
    {
        //Collider
        _collider.isTrigger = true;
        
        //Rigidbody
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
    private void Update()
    {
        transform.position += transform.forward * _missile.Speed * Time.deltaTime;
        _lifeTime -= Time.deltaTime;
        if (_lifeTime<=0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == hittableMask)
        { 
            other.GetComponent<Actor>()?.TakeDamage(_missile.Damage); 
        }
    }
}