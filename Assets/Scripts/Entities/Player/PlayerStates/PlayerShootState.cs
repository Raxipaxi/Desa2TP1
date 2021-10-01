public class PlayerShootState<T> : State<T>
{    
    T _inputIdle;
    private Player _player;

    public PlayerShootState(Player player, T inputIdle)
    {
        _player = player;
        _inputIdle = inputIdle;
    }

    public override void Execute()
    {
        _player.Attack();
        
        _fsm.Transition(_inputIdle);
    }
}
