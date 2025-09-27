using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboard;
    [SerializeField] private Text _timer;
    [SerializeField] private int _minutes;
    [SerializeField] private List<Text> _leaderboardNames = new List<Text>();

    public Dictionary<PlayerController1, int> _players = new Dictionary<PlayerController1, int>();

    [Obsolete]
    private void Awake()
    {
        PlayerController1[] players = FindObjectsOfType<PlayerController1>();   
        for (int i = 0; i < players.Length; i++)
        {
            _players.Add(players[i], i + 1);
        }

        StartCoroutine(Timer());
        StartCoroutine(LeaderboardUpdate());

        if (players.Length == _leaderboardNames.Count) return;
        for (int i = 0; i < _leaderboardNames.Count - players.Length; i++)
        {
            _leaderboardNames[_leaderboardNames.Count - i - 1].gameObject.SetActive(false);
        }
    }

    void checkPlayerScores()
    {
        List<PlayerController1> players = _players.Keys.ToList();
        players.Sort((a, b) => b.Score.CompareTo(a.Score));
    
        for (int i = 0; i < players.Count; i++)
        {
            _leaderboardNames[i].text = $"#1 player{_players[players[i]]} ({players[i].Score})";
        }
    }

    IEnumerator Timer()
    {
        for (int i = 1; i <= _minutes; i++)
        {
            for (int j = 1; j <= 60; j++)
            {
                _timer.text = $"{_minutes - i}:{60 - j}";
                yield return new WaitForSeconds(1);
            }
        }
        SceneManager.LoadScene("EndScreen");
    }
    IEnumerator LeaderboardUpdate()
    {
        while (true)
        {
            checkPlayerScores();
            yield return new WaitForSeconds(1);
        }
    }
}
