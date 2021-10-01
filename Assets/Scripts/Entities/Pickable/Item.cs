using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class Item : MonoBehaviour, IPickable
{
    public string Name => _name;
    public string _name;
    public Actor Owner => _owner;
    public Actor _owner;

    private SphereCollider _sphereCollider;

    public int hittableMask;
    private float _radius;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _radius = transform.localScale.z;
        _sphereCollider.radius = _radius;
    }
    

    public virtual void BePicked(Actor _picker)
    {
        SetOwner(_picker);
        transform.position = _owner.transform.position;
    }

    public virtual void BeDropped()
    {
        _owner = null;
    }

    public bool IsInrange(Actor _picker)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Resolve()
    {
        Debug.Log("Reloading");
    }
    
    public virtual void SetOwner(Actor _picker)
    {
        _owner = _picker;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
