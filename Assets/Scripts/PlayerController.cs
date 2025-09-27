using Unity.Cinemachine;
using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _camera;
    [Header("Player Stats")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _rotateSpeed = 2.5f;
    [SerializeField] private CinemachineInputAxisController _control;
    [SerializeField] private CinemachineBrain _brain;
    [SerializeField] private CinemachineCamera _cineCam;

    public int PlayerCount;

    private Vector3 _velocity;
    private Vector3 _movementDirection;

    private Vector2 _movementInput;
    private Vector2 _lookInput;


    private PlayerControls _controls;

    public bool IsGround;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _brain.ChannelMask = (OutputChannels)(1 << PlayerCount);
        _cineCam.OutputChannel = (OutputChannels)(1 << PlayerCount);
    }
            
    void Update()
    {
        
        ApplyGravity();
        ApplyMovement();
        ApplyRotation();
        IsGround = _controller.isGrounded;
    }

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
        Vector3 movementDirectionZ = transform.right * _movementInput.x;
        Vector3 movementDirectionX = transform.forward * _movementInput.y;
        _movementDirection = (movementDirectionX + movementDirectionZ).normalized;
        transform.Translate(_movementDirection * (_movementSpeed * Time.deltaTime), Space.World);
    }

    private void ApplyRotation()
    {
        transform.forward = new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z);
    }

    public void OnMove(InputValue input)
    {
        _movementInput = input.Get<Vector2>();
        Debug.Log(_movementInput);
    }

    public void OnLook(InputValue input)
    {
        _lookInput = input.Get<Vector2>();
    }
    public void OnAttack(InputValue value)
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

    public void OnJump(InputValue value)
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
