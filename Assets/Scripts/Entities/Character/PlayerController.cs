using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player Properties

    #region Properties

    private FSM<PlayerStates> _fsm;
    private Actor _player;
    private iInput _playerInput;
    #endregion

    #endregion
    
    
    
    #region Unity Methods

    

    private void Awake()
    {
        _player = GetComponent<Actor>();
        _playerInput = GetComponent<iInput>();
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region FSM

    

    #endregion
    

}