using System;
using System.Collections.Generic;
using UnityEngine;

public class MissileFactory : Factory<MissileAbstract>
{
    [SerializeField] private MissileAbstract[] _missileList;

    private Dictionary<string, MissileAbstract> _idMissile;

    private void Awake()
    {
        _idMissile = new Dictionary<string, MissileAbstract>();
        foreach (var missile in _missileList)
        {
            _idMissile.Add(missile.Id,missile);
        }
    }

    public MissileAbstract Create(string id, Transform transform)
    {
        if (!_idMissile.TryGetValue(id, out var missile)) throw new Exception("That missile does not exist");

        return Instantiate(missile, transform.position, Quaternion.identity);
    }
}
