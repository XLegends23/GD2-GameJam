using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnScript : MonoBehaviour
{
    [SerializeField] OutputChannels[] OutputChannels;
    [SerializeField] private Transform[] spawnPoints;
    private int _playerCount = 0;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnPoints[_playerCount].transform.position;
        PlayerInput player = PlayerInput.GetPlayerByIndex(_playerCount);
        _playerCount++;
    }
}
        