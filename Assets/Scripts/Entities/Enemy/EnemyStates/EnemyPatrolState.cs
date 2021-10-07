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
    private Transform _targetTransform;
    
    //--Obstacle avoidance
    ObstacleAvoidance _obs;
    public float radiusObs; 
    public float multiplierObs;
    public LayerMask maskObs;
    
    private ISteering _seek;
    [SerializeField] private Transform[] _patrolPoints;
    private Transform _currpatrolPoint =null;
    
    // Line of Sight Parameters
    public float range = 10;
    public float angle = 90;

    #endregion

    public EnemyPatrolState(Enemy enemy, T inputIdle, iNode root)
    {
        _enemy = enemy;
        _inputIdle = inputIdle;
        _root = root;
   
        _transform = _enemy.transform;
        _targetTransform = _enemy._target.transform;

    }

    public override void Awake()
    {
        // Start point to patrol
        if (_currpatrolPoint == null)
        {
            _currpatrolPoint = NearestPatPoint();
            _seek = new Seek(_transform, _currpatrolPoint);
            _obs = new ObstacleAvoidance(_transform, _currpatrolPoint, radiusObs, 5, multiplierObs, maskObs);
        }
    }

    public override void Execute()
    {
        
        // Goes to the patrolPoint
        _currDir = _obs.GetDir(_seek.GetDir());
        _enemy.Walk(_currDir);

        // Checks if reach the patrol point or sees the player stops the patrol action
        if (IsInSight() || Vector3.Distance(_transform.position, _currpatrolPoint.position)<0.2f)
        {
            _currpatrolPoint = null;
            _root.Execute(); 
        }
        
        // if (!_enemy.Patrol())
        // {
        //     _root.Execute();
        //     _fsm.Transition(_inputIdle); // Reaching a patrol point change to idle before Patrol again
        // }
       
        
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
    #region LineOfSight

    // public bool IsInSight(Transform target)
    public bool IsInSight() // ver de pasarlo a una clase
    {
        Vector3 diff = _targetTransform.position - _transform.position;
        float distance = diff.magnitude;
        if (distance > range) return false;

        Vector3 front = _transform.forward;

        if (!InAngle(diff, front)) return false;

        if (!IsInView(diff.normalized, distance, maskObs)) return false;

        return true;
    }
    bool InAngle(Vector3 from, Vector3 to)
    {
        float angleToTarget = Vector3.Angle(from, to);
        return angleToTarget < angle / 2;
    }
    bool IsInView(Vector3 dirToTarget, float distance, LayerMask maskObstacle)
    {
        return !Physics.Raycast(_transform.position, dirToTarget, distance, maskObstacle);
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

    #endregion
}
