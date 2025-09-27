using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerControls.IPlayerActions
{
    [Header("Objects")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _camera;
    [Header("Player Stats")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight;
    [Header("Camera Settings")]
    [SerializeField] private float _cameraXSensitivity = 5f;
    [SerializeField] private float _cameraYSensitivity = 5f;
    [SerializeField] private float _lookLimitY = 89f;

    private Vector3 _velocity;
    private Vector3 _movementDirection;

    private Vector2 _movementInput;
    private Vector2 _lookInput;
    private Vector2 _cameraRotation = Vector2.zero;
    private Vector2 _playerTargetRotation = Vector2.zero;

    private PlayerControls _controls;

    public bool IsGround;

    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Player.Enable();
        _controls.Player.SetCallbacks(this);
    }

    void Update()
    {
        _controller.Move(_velocity * Time.deltaTime);
        IsGround = _controller.isGrounded;
        ApplyGravity();
        ApplyMovement();
    }

    //private void LateUpdate()
    //{
    //    ApplyLooking();
    //}

    void ApplyGravity()
    {
        if (_controller.isGrounded)
        {
            _velocity.y = Physics.gravity.y * _controller.skinWidth;
            return;
        }
        _velocity.y += Physics.gravity.y * Time.deltaTime;
    }

    void ApplyMovement()
    {
        _movementDirection = new Vector3(_movementInput.x, 0, _movementInput.y);
        _controller.Move(_movementDirection * Time.deltaTime * _movementSpeed);
    }
    //void ApplyLooking()
    //{
    //    _cameraRotation.x += _cameraXSensitivity * _lookInput.x;
    //    _cameraRotation.y =
    //        Mathf.Clamp(_cameraRotation.y - _cameraYSensitivity * _lookInput.y, -_lookLimitY, _lookLimitY);
        
    //    _playerTargetRotation.x += transform.eulerAngles.x + _cameraXSensitivity * _lookInput.x;
    //    transform.rotation = Quaternion.Euler(0f, _playerTargetRotation.x, 0f);

    //    _camera.transform.rotation = Quaternion.Euler(_cameraRotation.y, _cameraRotation.x,0f);
    //}

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        Debug.Log(_movementInput);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //_lookInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("try jump");
        if (IsGround)
        {
            _velocity.y += _jumpHeight;
        }
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
