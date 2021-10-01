using UnityEngine;

public class PlayerInput : MonoBehaviour,  iInput
{
    #region Properties
    public float GetH => _xAxis;
    public float GetV => _zAxis;
    private Player _character ;//sacar desp
    private Vector3 _mousePointer;
    float _xAxis;
    float _zAxis;
    [Header("The canon")]
    private Transform _canon;

    public float adjustSensitivity = 1000f;

    private Transform _transform;
    private Camera _camera;
    private Vector3 currPos;

    #endregion

    private void Awake()
    {
        _character = GetComponent<Player>();
    }


    private void Start()
    {
        _camera = Camera.main;
        _transform = transform;
        
    }


    // Update is called once per frame
    // void Update()
    // {
    //     GetMousePosition();
    //     GetInputs();
    //     GiveOrder();
    // }

    #region Methods

    void GetMousePosition()
    {
        _mousePointer = _camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * adjustSensitivity);
        
    }
    void GetInputs()
    {   
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

       
    }

    void GiveOrder()
    {
 
        if (_xAxis != 0 || _zAxis != 0)
        {
            Vector3 dir = new Vector3(_xAxis, 0, _zAxis);
            _character.Move(dir);
        }

        
        
        if (Input.GetMouseButtonDown(0))
        {
            //_character.Attack();
        }
    }

    void RotateCanon()
    {
        var dir = _canon.position;
        _canon.forward = new Vector3(_mousePointer.x - dir.x, dir.y, _mousePointer.z - dir.z);
    }

    #endregion


    public bool IsMoving()
    {
        return (_xAxis != 0 || _zAxis != 0);
    }

    public bool IsShooting()
    {
        return Input.GetMouseButton(0);
    }
    public void UpdateInputs()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
        RotateCanon();
    }

    public Transform GetCanonTr()
    {
        return _canon;
    }
}
