using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class Item : MonoBehaviour, IPickable
{
    public string Name => _name;
    public string _name;
    public Character Owner => _owner;
    public Character _owner;

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
    

    public virtual void BePicked(Character _picker)
    {
        SetOwner(_picker);
        transform.position = _owner.transform.position;
    }

    public virtual void BeDropped()
    {
        _owner = null;
    }

    public bool IsInrange(Character _picker)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Resolve()
    {
        Debug.Log("Reloading");
    }
    
    public virtual void SetOwner(Character _picker)
    {
        _owner = _picker;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
