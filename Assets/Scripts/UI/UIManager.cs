using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Player _player;


    public HealthUI _healthUI;
    public AmmoUI _ammoUI;

    private void Start()
    {
        _ammoUI.SetMaxAmmo(_player._tank.MaxAmmo);
        _ammoUI.SetCurrAmmo(_player._tank.InitAmmo);
        _healthUI.InitSlider(_player.MaxLife);
    }

    private void OnEnable()
    {
        _player.OnDamageReceived += _healthUI.ModifyHealthbar;
       // _player._ammo.OnPickAmmo += _ammoUI.SetCurrAmmo;
      //  _player._ammo.OnUsingAmmo += _ammoUI.SetCurrAmmo;
    }

    private void OnDisable()
    {
        _player.OnDamageReceived -= _healthUI.ModifyHealthbar;
     //   _player._ammo.OnPickAmmo -= _ammoUI.SetCurrAmmo;
     //   _player._ammo.OnUsingAmmo -= _ammoUI.SetCurrAmmo;
    }
}
