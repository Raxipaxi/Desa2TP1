using System;
using UnityEngine;

public class PlayerInput :  MonoBehaviour
{
    #region Properties
    
    private Character _character ;//sacar desp
    private Vector3 _mousePointer;
    float _xAxis;
    float _zAxis;
    [Header("The canon")]
    public Transform _canon;

    public float adjustSensitivity = 1000f;

    private Transform _transform;
    private Camera _camera;
    private Vector3 currPos;

    #endregion

    private void Awake()
    {
        _character = GetComponent<Character>();
    }


    private void Start()
    {
        _camera = Camera.main;
        _transform = transform;
        
    }


    // Update is called once per frame
    void Update()
    {
        GetMousePosition();
        GetInputs();
        GiveOrder();
    }

    #region Methods

    void GetMousePosition()
    {
        _mousePointer = _camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * adjustSensitivity);
        
    }
    void GetInputs()
    {   
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        _zAxis = _zAxis * _character.GetSpeed() * Time.deltaTime;
        _xAxis = _xAxis * _character.GetSpeed() * Time.deltaTime;
        
    }

    void GiveOrder()
    {
 
        if (_xAxis != 0 || _zAxis != 0)
        {
            Vector3 dir = new Vector3(_xAxis, 0, _zAxis);
            _character.Move(dir);
        }

        RotateCanon();
        
        if (Input.GetMouseButtonDown(0))
        {
            //_character.Attack();
        }
    }

    void RotateCanon()
    {
        // currPos = _camera.ScreenToWorldPoint(_transform.position);
        // float angle = Vector3.Angle(currPos, _mousePointer);
        // _canon.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

        var dir = _canon.position;
        _canon.forward = new Vector3(_mousePointer.x - dir.x, dir.y, _mousePointer.z - dir.z);

    }

    #endregion

}
