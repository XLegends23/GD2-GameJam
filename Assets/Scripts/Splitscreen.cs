using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class Splitscreen : MonoBehaviour
{
    private Camera _cam;
    private int _index;
    private int _totalPlayers;

    private void Awake()
    {
        PlayerInputManager.instance.onPlayerJoined += HandlePlayerJoined;
    }

    private void Start()
    {
        _index = GetComponentInParent<PlayerInput>().playerIndex;
        _totalPlayers = PlayerInput.all.Count;
        _cam = GetComponent<Camera>();
        _cam.depth = _index;

        SetupCamera();
    }

    private void HandlePlayerJoined(PlayerInput obj)
    {
        _totalPlayers = PlayerInput.all.Count;
        SetupCamera();
    }

    private void SetupCamera()
    {
        if (_totalPlayers == 1)
        {
            _cam.rect = new Rect(0, 0, 1, 1);
        }
        else if (_totalPlayers == 2)
        {
            _cam.rect = new Rect(_index == 0 ? 0 : 0.5f, 0, 0.5f, 1);
        }
        else if (_totalPlayers == 3)
        {
            _cam.rect = new Rect(_index == 0 ? 0 : (_index == 1 ? 0.5f : 0), _index < 2 ? 0.5f : 0,
                _index < 2 ? 0.5f : 1, 0.5f);
        }
        else
        {
            _cam.rect = new Rect((_index % 2) * 0.5f, (_index < 2) ? 0.5f : 0f, 0.5f, 0.5f);
        }
    }

    private void Update()
    {

    }
}
