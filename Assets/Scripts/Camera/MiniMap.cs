using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform _player;
    private Transform _transform;

    public void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        if (_player!=null)
        {
            Vector3 newPos = _player.position;
            newPos.y = _transform.position.y;
            _transform.position = newPos;
        }

    }
}
