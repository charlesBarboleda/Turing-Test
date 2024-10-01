using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Briefing,
    LevelStart,
    LevelIn,
    LevelEnd,
    GameOver,
    GameEnd
}

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelManager[] _levels;
    public static GameManager Instance { get; private set; }
    GameState _currentState;
    LevelManager _currentLevel;
    int _currentLevelIndex = 0;
    bool _isInputActive = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        if (_levels.Length > 0)
        {
            ChangeState(GameState.Briefing, _levels[_currentLevelIndex]);
        }
    }

    public void ChangeState(GameState state, LevelManager level)
    {
        _currentState = state;
        _currentLevel = level;
        switch (state)
        {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitiateLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
        }
    }

    public bool IsInputActive()
    {
        return _isInputActive;
    }

    void StartBriefing()
    {
        _isInputActive = false;
        ChangeState(GameState.LevelStart, _currentLevel);
    }

    void InitiateLevel()
    {
        _isInputActive = true;
        _currentLevel.StartLevel();

        ChangeState(GameState.LevelIn, _currentLevel);
    }

    void RunLevel()
    {
        // Put any in-round logic here
    }

    void CompleteLevel()
    {
        ChangeState(GameState.LevelEnd, _levels[++_currentLevelIndex]);
    }

    void GameOver()
    {

    }

    void GameEnd()
    {

    }
}
