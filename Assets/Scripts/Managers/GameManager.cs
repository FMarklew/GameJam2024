using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    public GameObject player => _player;

    [SerializeField] private List<LevelController> _levels;

    private static GameManager _instance;
    private GameObject _player;
    private int _currentLevel = 0;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        Application.targetFrameRate = 60;

        _levels[_currentLevel].StartLevel();
    }

    public void OnLevelComplete()
    {
        // level transition
    }

    public void StartNextLevel()
    {
        _currentLevel++;

        if(_currentLevel >= _levels.Count)
        {
            _currentLevel = 0;
        }

        _levels[_currentLevel].StartLevel();
    }
}
