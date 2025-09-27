using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnScript : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private int _playerCount;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnPoints[_playerCount].transform.position;
        _playerCount++;
    }
}
