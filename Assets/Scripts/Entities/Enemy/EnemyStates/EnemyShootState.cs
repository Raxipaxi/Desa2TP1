using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class EnemyShootState<T> : State<T>
{
    #region Properties
    private Enemy _enemy;
    private iNode _root;
    
  
    #endregion
    public EnemyShootState(Enemy enemy, iNode root)
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
