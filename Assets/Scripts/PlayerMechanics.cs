using System.Collections;
using Unity.Cinemachine.Samples;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMechanics : MonoBehaviour, PlayerControls.IPlayerActions
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private SimplePlayerController _playerController;

    private IEnumerator _attack;
    private IEnumerator _stun;

    private PlayerControls _controls;

    public int Score { get; private set; }

    void Awake()
    {
        _controls = new PlayerControls();
        _controls.Player.Enable();
        _controls.Player.SetCallbacks(this);
    }

    void OnParticleCollision()
    {
        Debug.Log("hit");
        if (_stun != null) return;
        _stun = Stun();
        StartCoroutine(_stun);
    }

    IEnumerator Attack()
    {
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        _attack = null;
    }
    IEnumerator Stun()
    {
        _playerController.enabled = false;
        yield return new WaitForSeconds(3);
        _stun = null;
        _playerController.enabled = true;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
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
        throw new System.NotImplementedException();
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
