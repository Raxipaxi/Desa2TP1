using UnityEngine;

public class EnemyPatrolState<T> : State<T>
{
    #region Properties

    //private T _inputIdle;
    private Enemy _enemy;
    private iNode _root;
    

    //Steering Variables
    //
    private Vector3 _currDir;
    private Transform _transform;
  
    //--Obstacle avoidance
    ObstacleAvoidance _obs;

    private ISteering _seek;
    private Transform[] _patrolPoints;
    private Transform _currpatrolPoint =null;

    #endregion

    public EnemyPatrolState(Enemy enemy, T inputIdle, iNode root, ObstacleAvoidance obs, Transform[] patrolPoints)
    {
        _enemy = enemy;
        //_inputIdle = inputIdle;
        _root = root;
        _obs = obs;
        _patrolPoints = patrolPoints;
   
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
           // _fsm.Transition(_inputIdle); // Reaching a patrol point change to idle before Patrol again
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
    
}
