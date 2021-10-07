using UnityEngine;

public class EnemyController : MonoBehaviour
{
    

    #region Properties

    [SerializeField] private float attackRange;

    [SerializeField] private Player target;
    // Decision Tree and FSM Variables 
    private FSM<EnemyStates> _fsm;
    Enemy _enemy;
    iNode _root;

   
    private ISteering _seek;
    private ISteering _chase;
    
    // -- Obstacle Avoidance Variables
    public ObstacleAvoidance _obs;
    public float radiusObs; 
    public float multiplierObs;
    public LayerMask maskObs;
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
        _obs = new ObstacleAvoidance(transform, target.transform, radiusObs, maxObjects, multiplierObs, maskObs);
    }
    #region FSM
    private void FsmInit()
    {
        //--------------- FSM Creation -------------------//     
        //------States creation
        var idle = new EnemyIdleState<EnemyStates>(_enemy, EnemyStates.Patrol,_root);
        var patrol = new EnemyPatrolState<EnemyStates>(_enemy,EnemyStates.Idle, _root, _obs);
        var follow = new EnemyFollowState<EnemyStates>(_enemy,EnemyStates.Patrol, _root, _obs);
        var attack = new EnemyAttackState<EnemyStates>(_enemy, _root);
        
        //------ Idle
        idle.AddTransition(EnemyStates.Chase, follow);
        idle.AddTransition(EnemyStates.Patrol, patrol);
     
        //------ Follow -- 
        follow.AddTransition(EnemyStates.Patrol, patrol);
        follow.AddTransition(EnemyStates.Shoot, attack);
       
        // ----- Patrol ---
        patrol.AddTransition(EnemyStates.Idle, idle);
        patrol.AddTransition(EnemyStates.Chase,follow);
        
        // ----- Attack ---
        attack.AddTransition(EnemyStates.Chase, follow);
        attack.AddTransition(EnemyStates.Patrol, patrol);
        
        
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
        return _enemy.IsInSight();
    }

    bool IsInIdle()
    {
        return true; // check
    }

    bool IsInRange()
    {
        return (Vector3.Distance(transform.position, target.transform.position) < attackRange);
    }

    #endregion
    
    #endregion

    void Update()
    {
        if (target != null) 
        {
            _fsm.OnUpdate();
        }
    }
    
}
