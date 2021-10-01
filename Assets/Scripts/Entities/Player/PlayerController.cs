using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player Properties

    #region Properties

    private FSM<PlayerStates> _fsm;
    private Player _player;
    private iInput _playerInput;
    #endregion

    #endregion
   
    #region Unity Methods
    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<iInput>();

        FsmInit();
    }

    private void Update()
    {
        if (_player != null)
        {
            _fsm.OnUpdate();
        }
    }
    #endregion

    #region FSM
    private void FsmInit()
    {
        //--------------- FSM Creation -------------------//                
        // States Creation
        var idle = new PlayerIdleState<PlayerStates>(_player, PlayerStates.Move,PlayerStates.Shoot,_playerInput );
        var move = new PlayerMoveState<PlayerStates>(_player, PlayerStates.Idle,PlayerStates.Shoot, _playerInput);
        var shoot = new PlayerShootState<PlayerStates>(_player, PlayerStates.Idle);
        var dead = new PlayerDeadState<PlayerStates>(_player);
        
        // Idle State
        idle.AddTransition(PlayerStates.Move, move);
        idle.AddTransition(PlayerStates.Shoot, shoot);
        idle.AddTransition(PlayerStates.Dead, dead);
        
        // Move State
        move.AddTransition(PlayerStates.Idle, idle);
        move.AddTransition(PlayerStates.Shoot, shoot);
        move.AddTransition(PlayerStates.Dead, dead);
        
        // Shoot State
        shoot.AddTransition(PlayerStates.Idle, idle);
        
        _fsm = new FSM<PlayerStates>();
        // Set init state
        _fsm.SetInit(idle);

    }
    
    #endregion

}