using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    string Name { get; }
    Actor Owner { get; }
    public void BePicked(Actor _picker);
    
}
