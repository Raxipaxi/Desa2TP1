using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour, IDamageable, iMobile
{
    public float CurrentLife => _life;
    
    [SerializeField]private float _life = 100;

    public float MaxLife => _maxLife;
    [SerializeField]private float _maxLife = 100;

    public virtual void TakeDamage(float damage)
    {
        _life -= damage;
        
        
       // Debug.Log($"{name} remaining life {_life}");
        if (_life <=0)
        {
           // Debug.Log($"{name} Died!!");
        }
    }

    public virtual void RecoverLife(int _heal)
    {
        _life += _heal;
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Idle()
    {
        throw new NotImplementedException();
    }

    public virtual void Walk(Vector3 dir)
    {
        throw new NotImplementedException();
    }

    public virtual void Attack(int dmg)
    {
    }

    public virtual bool Patrol()
    {
        throw new NotImplementedException();
    }

    public virtual void Chase()
    {
        throw new NotImplementedException();
    }

    public virtual void Move(Vector3 dir, float speed)
    {
        throw new NotImplementedException();
    }

    public void Run(Vector3 dir)
    {
        throw new NotImplementedException();
    }
}
