using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Properties

    [SerializeField] private float attackRange;
    
    //Target Transform
    private Player Target => _enemy.target;
    
    // Decision Tree and FSM Variables 
    private FSM<EnemyStates> _fsm;
    Enemy _enemy;
    iNode _root;
    
    bool isInRange => Vector3.Distance(transform.position, Target.transform.position) < attackRange;

   // Steering Behavior
    private ISteering _seek;
    private ISteering _chase;
    
    // Patrol State parameters
    [SerializeField] public Transform[] patrolPoints;
    
    // -- Obstacle Avoidance Variables
    public ObstacleAvoidance Obs;
    public float radiusObs; 
    public float multiplierObs;
    private  LayerMask MaskObs => _enemy.GetMaskObs();
    public int maxObjects;

    

    #endregion
    void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void Start()
    {
        InitObstacleAvoid();
        InitTree();
        FsmInit();
        
    }

    void InitObstacleAvoid()
    {
        Obs = new ObstacleAvoidance(transform, Target.transform, radiusObs, maxObjects, multiplierObs, MaskObs);
    }
    #region FSM
    private void FsmInit()
    {
        //--------------- FSM Creation -------------------//     
        //------States creation
        var idle = new EnemyIdleState<EnemyStates>(_enemy, EnemyStates.Patrol,_root);
        var patrol = new EnemyPatrolState<EnemyStates>(_enemy,EnemyStates.Idle, _root, Obs, patrolPoints);
        var follow = new EnemyFollowState<EnemyStates>(_enemy,EnemyStates.Patrol, _root, Obs);
        var shoot = new EnemyShootState<EnemyStates>(_enemy, _root);
        
        //------ Idle
        idle.AddTransition(EnemyStates.Chase, follow);
        idle.AddTransition(EnemyStates.Patrol, patrol);
        idle.AddTransition(EnemyStates.Shoot,shoot);
     
        //------ Follow -- 
        follow.AddTransition(EnemyStates.Patrol, patrol);
        follow.AddTransition(EnemyStates.Idle,idle);
        follow.AddTransition(EnemyStates.Shoot, shoot);
        
       
        // ----- Patrol ---
        patrol.AddTransition(EnemyStates.Idle, idle);
        patrol.AddTransition(EnemyStates.Chase,follow);
        patrol.AddTransition(EnemyStates.Shoot,shoot);
        
        // ----- Attack ---
        shoot.AddTransition(EnemyStates.Chase, follow);
        shoot.AddTransition(EnemyStates.Patrol, patrol);
        shoot.AddTransition(EnemyStates.Idle,idle);
        
        
        _fsm = new FSM<EnemyStates>();
        // Set init state
        _fsm.SetInit(idle);

    }
    #endregion
    
    #region DecitionTree
    void InitTree(){
    // Actions

          iNode follow = new ActionNode(()=> _fsm.Transition(EnemyStates.Chase));
          iNode patrol = new ActionNode(()=> _fsm.Transition(EnemyStates.Patrol));
          iNode attack = new ActionNode(()=> _fsm.Transition(EnemyStates.Shoot));
          iNode idle = new ActionNode(() => _fsm.Transition(EnemyStates.Idle));
        
    //Questions
          iNode isInIdle = new QuestionNode(IsInIdle, patrol, idle); 
          iNode isInSight = new QuestionNode(IsInSight,follow,isInIdle); // Is the player in sight?      
          iNode isInRange = new QuestionNode(IsInRange,attack,isInSight); // Is in range to attack?
           
          _root = isInRange;
    }

   
    #region Questions
    bool IsInSight()
    {
       // Debug.Log("Te pillé" + _enemy.IsInSight());
        return _enemy.IsInSight();
    }

    bool IsInIdle()
    {
        return true; // check
    }

    bool IsInRange()
    {
      //  Debug.Log("Pew Pew :  "+ isInRange + "  " + IsInSight() );
        return isInRange&&IsInSight();
        // return ((Vector3.Distance(transform.position, Target.transform.position) < attackRange)&&IsInSight());
    }

    #endregion
    
    #endregion

    void Update()
    {
        if (Target != null) 
        {
            _fsm.OnUpdate();
        }
    }
    
}
