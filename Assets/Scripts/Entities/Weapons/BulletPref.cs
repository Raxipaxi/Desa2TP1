using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class BulletPref : MonoBehaviour
{
    #region Properties
    [SerializeField] private float speed = 20f;
    // [SerializeField] private Gun _owner;
    private LayerMask hittableMask;
    [SerializeField] private float _lifeTime = 3f;

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
        transform.position += transform.forward * speed * Time.deltaTime;
        _lifeTime -= Time.deltaTime;
        if (_lifeTime<=0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == hittableMask)
        { 
            other.GetComponent<Actor>()?.TakeDamage(10); 
        }
    }
}
