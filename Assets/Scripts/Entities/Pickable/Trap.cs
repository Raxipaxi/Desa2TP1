using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class Trap : Item
 {
     
     [SerializeField] private int _damage = 10;
     private void OnTriggerEnter(Collider other)
     {
         if (other.GetComponent<Actor>() != null)
         {
             BePicked(other.GetComponent<Actor>());
         }
     }

     public override void BePicked(Actor _picker)
     {
         if (_picker.gameObject.layer == hittableMask)
         {
             
             _picker.GetComponent<Actor>()?.TakeDamage(_damage); 
         }
         Resolve();
     }

     public override void Resolve()
     {
         Debug.Log("BOOOM");
         Destroy(gameObject);
     }
 }