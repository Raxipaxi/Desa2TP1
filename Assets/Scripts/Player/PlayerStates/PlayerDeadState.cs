
public class PlayerDeadState<T> : State<T>
{
    private Actor _player;

    public PlayerDeadState(Actor player)
    {
      _player = player;
    }

    public override void Execute()
    {
        _player.Die();
    }
}


