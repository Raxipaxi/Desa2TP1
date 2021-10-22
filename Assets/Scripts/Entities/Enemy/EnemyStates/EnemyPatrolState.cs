using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState<T> : State<T>
{
    #region Properties

    private Enemy _enemy;
    private iNode _root;
    private HashSet<Transform> visitedWP = new HashSet<Transform>();

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
            if (!visitedWP.Contains(_currpatrolPoint)) visitedWP.Add(_currpatrolPoint);
            
            _seek = new Seek(_transform, _currpatrolPoint);
            _obs.SetTarget(_currpatrolPoint);
            _obs.SetSelf(_transform);
        }
    }

    public override void Execute()
    {
        
        // Goes to the patrolPoint
        
        _currDir = _obs.GetDir(_seek.GetDir());
        _enemy.Move(_currDir, _enemy.GetSpeed());

        // Checks if reach the patrol point or sees the player stops the patrol action
        if (!_enemy.IsInSight() && Vector3.Distance(_transform.position, _currpatrolPoint.position)<0.5f)
        {

            _currpatrolPoint = NearestPatPoint();
            visitedWP.Add(_currpatrolPoint);
            
            _seek = new Seek(_transform, _currpatrolPoint);
            _obs.SetTarget(_currpatrolPoint);
            _obs.SetSelf(_transform);

            _root.Execute(); 
        }
        
        _root.Execute();
        // _fsm.Transition(_inputIdle); // Reaching a patrol point change to idle before Patrol again

       
        
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
            if (currDist<minDist)
            {
                if (_currpatrolPoint!=null)
                {
                    if (currDist>Vector3.Distance(_transform.position,_currpatrolPoint.position)&&!visitedWP.Contains(_patrolPoints[i]))
                    {
                        
                        minDist = currDist;
                        nearestPatrolpt = _patrolPoints[i]; 
                    }
                }
                else
                {
                    minDist = currDist;
                    nearestPatrolpt = _patrolPoints[i];    
                }
            }
        }
        if (visitedWP.Count.Equals(_patrolPoints.Length)) CleanVisitedWP();
        
        return nearestPatrolpt;
    }

    private void CleanVisitedWP()
    {
        visitedWP.Clear();
    }
    
}
