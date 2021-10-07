using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class EnemyAttackState<T> : State<T>
{
    #region Properties
    private Enemy _enemy;
    private iNode _root;
    
  
    #endregion
    public EnemyAttackState(Enemy enemy, iNode root)
    {
        _enemy = enemy;
        _root = root;
    }

    public override void Execute()
    {
        _enemy.Attack();
        _root.Execute();
        
    }
}
