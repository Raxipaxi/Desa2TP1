using UnityEngine;
using System;

public class Actor1 : MonoBehaviour, IDamageable, iMobile
{
    public int CurrentLife => _life;
    
    [SerializeField]private int _life = 100;

    public int MaxLife => _maxLife;
    [SerializeField]private int _maxLife = 100;


    #region iDamageable

    public virtual void TakeDamage(int x)
    {
        throw new NotImplementedException();
    }
    public virtual void Die()
    {
        throw new NotImplementedException();
    }


    #endregion

    #region iMobile

    public void Idle()
    {
        throw new NotImplementedException();
    }

    public virtual void Walk(Vector3 dir)
    {
        throw new NotImplementedException();
    }

    public virtual void Attack(int dmg)
    {
        throw new NotImplementedException();
    }

    public virtual void LookDir(Vector3 dir)
    {
        throw new NotImplementedException();
    }

    public virtual void Run(Vector3 dir)
    {
        throw new NotImplementedException();
    }

    public virtual void Move(Vector3 dir, float speed)
    {
        throw new NotImplementedException();
    }

    public virtual void Chase()
    {
        throw new NotImplementedException();
    }
    public virtual bool Patrol()
    {
        return true;
    }
    #endregion
    
}
