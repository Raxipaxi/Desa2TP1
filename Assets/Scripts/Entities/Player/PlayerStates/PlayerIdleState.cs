
public class PlayerIdleState<T> : State<T>
{
    T _inputMove;
    T _inputShoot;
    private Actor _player;
    private iInput _playerInput;

    public PlayerIdleState(Actor player, T inputMoveMove,T inputShoot, iInput playerInput)
    {
        _inputMove = inputMoveMove;
        _player = player;
        _playerInput = playerInput;
        _inputShoot = inputShoot;
    }


    public override void Execute()
    {
        _player.Idle();
        _playerInput.UpdateInputs();
        if (_playerInput.IsMoving())
        {
            _fsm.Transition(_inputMove);
        }
        else if (_playerInput.IsShooting())
        {
            _fsm.Transition(_inputShoot);
        }
 
    }
}
