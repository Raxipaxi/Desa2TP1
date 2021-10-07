using UnityEngine;

public class EnemyFollowState<T> : State<T>
{
    #region Properties

    private Enemy _enemy;
    private T _inputPatrol;
    private iNode _root;
    
    #endregion

    public EnemyFollowState(Enemy enemy,T inputPatrol, iNode root)
    {
        _enemy = enemy;
        _root = root;
        _inputPatrol = inputPatrol;
    }

    public override void Execute()
    {
        if (_enemy.IsInSight()) // Cambiar la pregunta para que se restrinja
        {
            _enemy.Chase();
            _root.Execute();
        }
        else
        {
            _fsm.Transition(_inputPatrol);
        }
        
    }
}
