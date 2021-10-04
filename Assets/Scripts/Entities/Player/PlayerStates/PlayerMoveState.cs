
using UnityEngine;

public class PlayerMoveState<T> : State<T>
{
    private T _inputIdle;
    private T _inputShoot;
    private Player _player;
    private iInput _playerInput;

    public PlayerMoveState(Player player, T inputIdleIdle, T inputIdleShoot, iInput playerInput)
    {
        _player = player;
        _inputIdle = inputIdleIdle;
        _inputShoot = inputIdleShoot;
        _playerInput = playerInput; 
    }

    public override void Execute()
    {
        _playerInput.UpdateInputs();
        var h = _playerInput.GetH;
        var v = _playerInput.GetV;
       
        if (_playerInput.IsMoving())
        {
            Vector3 dir = new Vector3(h, 0, v);
            _player.Move(dir.normalized, _player.GetSpeed());
            _player.LookAt(dir);
        }
        
        if (_playerInput.IsShooting())
        {
            _fsm.Transition(_inputShoot);
        }
        
        if(!_playerInput.IsMoving()&&!_playerInput.IsShooting())
        {
            _fsm.Transition(_inputIdle); 
        }
        
    }
}
