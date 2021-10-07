using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState<T> : State<T>
{
    #region Properties

    private T _inputIdle;
    private Enemy _enemy;
    private iNode _root;
    

    //Steering Variables
    //
    private Vector3 _currDir;
    private Transform _transform;
  
    //--Obstacle avoidance
    ObstacleAvoidance _obs;

    private ISteering _seek;
    [SerializeField] private Transform[] _patrolPoints;
    private Transform _currpatrolPoint =null;


    
    // Line of Sight Parameters
    public float range = 10;
    public float angle = 90;

    #endregion

    public EnemyPatrolState(Enemy enemy, T inputIdle, iNode root, ObstacleAvoidance obs)
    {
        _enemy = enemy;
        _inputIdle = inputIdle;
        _root = root;
        _obs = obs;
   
        _transform = _enemy.transform;
  
    }

    public override void Awake()
    {
        // Start point to patrol
        if (_currpatrolPoint == null)
        {
            _currpatrolPoint = NearestPatPoint();
            _seek = new Seek(_transform, _currpatrolPoint);
            _obs.SetTarget(_currpatrolPoint);
            _obs.SetSelf(_transform);
        }
    }

    public override void Execute()
    {
        
        // Goes to the patrolPoint
        _currDir = _obs.GetDir(_seek.GetDir());
        _enemy.Walk(_currDir);

        // Checks if reach the patrol point or sees the player stops the patrol action
        if (_enemy.IsInSight() || Vector3.Distance(_transform.position, _currpatrolPoint.position)<0.2f)
        {
            _currpatrolPoint = null;
            _root.Execute(); 
        }
        
        if (!_enemy.Patrol())
        {
            _root.Execute();
            _fsm.Transition(_inputIdle); // Reaching a patrol point change to idle before Patrol again
        }
       
        
    }
    //Look up the nearest patrolPoint
    private Transform NearestPatPoint()
    {
        float minDist= float.MaxValue;
        float currDist;
        Transform nearestPatrolpt= null;
        
        for (int i = 0; i < _patrolPoints.Length; i++)
        {
            currDist = Vector3.Distance(_transform.position, _patrolPoints[i].position);
            if (currDist<minDist&&currDist>0.5f)
            {
                minDist = currDist;
                nearestPatrolpt = _patrolPoints[i];
            }
        }
        
        return nearestPatrolpt;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_transform.position, range);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_transform.position, _transform.forward * range);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_transform.position, Quaternion.Euler(0, angle / 2, 0) * _transform.forward * range);
        Gizmos.DrawRay(_transform.position, Quaternion.Euler(0, -angle / 2, 0) * _transform.forward * range);
    }

   
}
