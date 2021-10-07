using System.Collections.Generic;
using UnityEngine;
public class EnemyAttackState<T> : State<T>
{
    #region Properties
    private T _inputPatrol;
    private T _inputFollow;
    private Enemy _enemy;
    
    // Attack dmg
    private Dictionary<int, float> damageProb;
    [SerializeField] private int normalDmg;
    [SerializeField] private int critDmg;
    
    #endregion

    public EnemyAttackState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public override void Awake()
    {
        // Set values in the Damage dictionary dmg/%
        damageProb = new Dictionary<int, float>();
        damageProb.Add(normalDmg,95);
        damageProb.Add(critDmg,5); // Could be in the controller this parameters?
    }

    public override void Execute()
    {
        // Prob to attack a critical hit
        Roulette roulette = new Roulette();
        var damage = roulette.Run(damageProb); 
        _enemy.Attack(damage);
    }
}
