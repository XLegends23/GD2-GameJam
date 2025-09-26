using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour, PlayerControls.IPlayerActions
{
    [Header("Objects")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _particleSystem;
    [Header("Player Stats")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeight;

    private Vector3 _velocity;
    private Vector3 _movementDirection;

    private Vector2 _movementInput;

    private PlayerControls _controls;

    private bool IsGround;

    private IEnumerator _attack;

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

    IEnumerator Attack()
    {
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        _attack = null;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
        Debug.Log(_movementInput);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (_attack != null)
        {
            return;
        }
        _attack = Attack();
        StartCoroutine(_attack);
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
