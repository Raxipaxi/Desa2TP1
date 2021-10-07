using System;
using UnityEngine;
public class AmmoBox : Item<Player>
{
    public int addammo = 20;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void BePicked(Player _picker)
    {
        SetOwner(_picker);
        Resolve();
        BeDropped();
        
    }

    public override void BeDropped()
    {
        _owner = null;
        Destroy(gameObject);
    }

    public override void Resolve()
    {
        _owner._ammo.PickAmmo(addammo);
    }

    public override void SetOwner(Player _picker)
    {
        _owner = _picker;
    }

    private void OnTriggerEnter(Collider _picker)
    {
        if (_picker.gameObject.layer == hittableMask)
        {
            if (_picker.GetComponent<Player>() != null)
            {
                BePicked(_picker.GetComponent<Player>());
            }
        }
    }
}
