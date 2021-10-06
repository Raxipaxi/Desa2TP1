using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item<T> : MonoBehaviour, IPickable<T>
{
    public string Name => _name;
    public string _name;
    public T Owner => _owner;
    public T _owner;


    public int hittableMask;
   

    public virtual void BePicked(T _picker)
    {
        SetOwner(_picker);
        
    }

    public virtual void BeDropped()
    {
        throw new System.NotImplementedException();
    }

    public bool IsInrange(T _picker)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Resolve()
    {
        Debug.Log("Reloading");
    }
    
    public virtual void SetOwner(T _picker)
    {
        _owner = _picker;
    }


}
