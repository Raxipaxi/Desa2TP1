using UnityEngine;
    public class Enemy : Actor
    {
        #region Properties

        private Transform _transform;
        private Rigidbody _rb;
        public Tanks _tank;
        private float _nextFire;
        public Player _target;
        
        // Line of Sight Parameters

        private LineOfSight _lineOfSight;
        public float range = 10;
        public float angle = 90;
        
        //Steering Variables
        //--Obstacle avoidance
        public LayerMask maskObs;
        
        #endregion
        #region Unity methods
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _lineOfSight = GetComponent<LineOfSight>();
            
        }
        private void Start()
        { 
            _transform = transform;
            _nextFire = 0;
        }
        
        #endregion

        #region Mobile methods
        public override void Move(Vector3 dir, float speed)
        {
            dir *= speed;
            dir.y = _rb.velocity.y;
            _rb.velocity = dir;
            LookAt(dir);
            
        }

        public float GetSpeed()
        {
            return _tank.Speed;
        }
        
        
        public void LookAt(Vector3 dir)
        {
            _transform.forward = dir;
        }
        public void Attack()
        {
            if (Time.time > _nextFire)
            {
                Debug.Log("si");
                _nextFire = Time.time + _tank.ShootCd;
            }
        }
        
        public override void Idle()
        {
            _rb.velocity = Vector3.zero;
        }
        #endregion

        void OnDie()
        {
            
        }
        #region LineOfSight

        // public bool IsInSight(Transform target)
        public bool IsInSight()
        {
            return _lineOfSight.IsInSight(_target.transform,transform, maskObs,range,angle);
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * range);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle / 2, 0) * transform.forward * range);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle / 2, 0) * transform.forward * range);
        }

        public LayerMask GetMaskObs()
        {
            return maskObs;
        }
        

        #endregion

    }
