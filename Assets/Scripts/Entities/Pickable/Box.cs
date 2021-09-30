using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Box : Item
{
    
    public override void BePicked(Character _picker)
    {
        SetOwner(_picker);
        Resolve();
    }

    public override void BeDropped()
    {
        _owner = null;
        transform.parent = null;
    }

    public override void Resolve()
    {
        transform.parent = _owner.transform;
    }

    public override void SetOwner(Character _picker)
    {
        _owner = _picker;
    }

    private void OnTriggerEnter(Collider _picker)
    {
        
        if (_picker.gameObject.layer == hittableMask && Input.GetKey(KeyCode.E))
        {
            if (_picker.GetComponent<Character>()!=null)
            {
                BePicked(_picker.GetComponent<Character>());
            }
           
        }
    }
}
