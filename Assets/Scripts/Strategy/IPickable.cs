using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    string Name { get; }
    Character Owner { get; }
    public void BePicked(Character _picker);
    
}
