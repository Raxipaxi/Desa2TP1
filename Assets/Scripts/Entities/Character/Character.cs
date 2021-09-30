using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : Actor
{
    //[SerializeField] private Gun _weapon;
    //[SerializeField] private Item _item;
    [SerializeField] private float speed = 2.5f;
    private bool isAttacking = false;
    private Transform _transform; 
    private Rigidbody _rb;

    #region Unity Methods

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        _transform = transform;
    }

    #endregion
    
    
    #region Actions
    public void Move(Vector3 dir)
    {
        // transform.position = transform.position + dir;
        Rotate(dir);
        dir *= speed;
        dir.y = _rb.velocity.y;
        _rb.velocity = dir;
  
    }

    public void Rotate(Vector3 dir)
    {
        _transform.forward = dir.normalized;
    }
    public void Attack()
    {
        Debug.Log("si");
    }
    
    



    #endregion

        

    public float GetSpeed()
    {
        return speed;
    }


    
}
