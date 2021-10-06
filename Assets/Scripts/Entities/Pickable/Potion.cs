// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
//
// public class Potion : Item<Player>
// {
//     
//     [SerializeField] private int _heal = 10;
//
//     private void Start()
//     {
//         hittableMask = LayerMask.NameToLayer("Actor");
//     }
//     public override void BePicked(Player owner)
//     {
//         SetOwner(owner);
//         Debug.Log($"{name} Apreta E");
//         // if (Input.GetKey(KeyCode.E))
//         // {
//             Debug.Log($"CURAAAA");
//             Resolve(_owner);
//         // }
//     }
//
//     public void Resolve(Actor _user)
//     {
//         Debug.Log("Deberia curar");
//         if (_user.MaxLife != _user.CurrentLife)
//         {
//             _user.RecoverLife(_heal);
//             Destroy(gameObject);
//         }
//         
//     }
//     private void OnTriggerEnter(Collider picker)
//     {
//         Debug.Log($"{name} entró en colisión");
//         Debug.Log($"{picker.gameObject.layer} Layer");
//         Debug.Log($"{hittableMask}            hittableMask");
//         
//         if (picker.gameObject.layer == hittableMask)
//         {
//             if (picker.GetComponent<Actor>()!=null)
//             {
//                 BePicked(picker.GetComponent<Actor>());
//             }
//            
//         }
//     }
// }
