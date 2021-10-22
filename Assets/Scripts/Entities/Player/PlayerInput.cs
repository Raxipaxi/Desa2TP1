using UnityEngine;

public class PlayerInput : MonoBehaviour,  iInput
{
    #region Properties
    public float GetH => _xAxis;
    public float GetV => _zAxis;
    private Vector3 _mousePointer;
    float _xAxis;
    float _zAxis;
    [Header("The canon")]
    [SerializeField ]private Transform _canon;
    public float adjustSensitivity = 1000f;

    private Transform _transform;
    private Camera _camera;
    private Vector3 currPos;

    #endregion

  private void Start()
    {
        _camera = Camera.main;
        
    }
    
    #region Methods

    void GetMousePosition()
    {
        _mousePointer = _camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * adjustSensitivity);
        
    }
    void RotateCanon()
    {
        var dir = _canon.position;
        _canon.forward = new Vector3(_mousePointer.x - dir.x, dir.y, _mousePointer.z - dir.z);
        _canon.rotation = Quaternion.Euler(0,_canon.eulerAngles.y,0);
       
    }

    #endregion

     
    public bool IsMoving()
    {
        return (GetH != 0 || GetV != 0);
    }

    public bool IsShooting()
    {
        return Input.GetMouseButtonDown(0);
    }
    public void UpdateInputs()
    {
        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");
        GetMousePosition();
        RotateCanon();
    }

    public Transform GetCanonTr()
    {
        return _canon;
    }
}
