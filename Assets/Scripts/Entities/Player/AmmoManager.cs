using System;
public class AmmoManager 
{
    /// <summary>
    /// Manage the ammount of ammo that can use the Actor
    /// </summary>
    public event Action<int> OnPickAmmo;
    public event Action<int> OnUsingAmmo;

    private int _currAmmo;
    private int _MaxAmmo;
    private bool _empty;

    public AmmoManager(int maxAmmo, int currAmmo)
    {
        _currAmmo = currAmmo;
        _MaxAmmo = maxAmmo;
        _empty = false;
    }
/// <summary>
/// Adds the ammount of ammo that the parameter indicates, if this exceeds the Max capability just set MaxAmmo as current
/// ammo
/// </summary>
/// <param name="addedAmmo"></param>
    public void PickAmmo(int addedAmmo)
    {
        _empty = false;
        if (!(addedAmmo+_currAmmo > _MaxAmmo))
        {
            _currAmmo += addedAmmo;
        }
        else
        {
            _currAmmo = _MaxAmmo;
        }
        OnPickAmmo?.Invoke(_currAmmo);
    }

    /// <summary>
    /// When ammo is asked by the Actor its return the quantity of ammo that is required, if the quantity exceeds
    /// the current amount returns the available ammo
    /// </summary>
    /// <param name="ammoReq"></param>
    /// <returns></returns>
    public int UseAmmo(int ammoReq)
    {
        int tempAmmo;
       
        if (!_empty)
        {
            if (ammoReq>_currAmmo)
            {
                tempAmmo = _currAmmo;
                _currAmmo = 0;
                _empty = true;
                OnUsingAmmo?.Invoke(_currAmmo);
                return tempAmmo;
            }
            else
            {
                _currAmmo -= ammoReq;
                if (_currAmmo == 0) _empty = true;
                OnUsingAmmo?.Invoke(_currAmmo);
            }
        }

        return _currAmmo;
    }

    public bool GetIsEmpty()
    {
        return _empty;
    }
}
