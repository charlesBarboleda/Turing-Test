using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] bool _isFinalLevel;
    public UnityEvent onLevelStart;
    public UnityEvent onLevelEnd;

    public void StartLevel()
    {
        onLevelStart.Invoke();
    }

    public void EndLevel()
    {
        onLevelEnd.Invoke();

        if (_isFinalLevel)
        {
            GameManager.Instance.ChangeState(GameState.GameEnd, this);
        }
        else
        {
            GameManager.Instance.ChangeState(GameState.LevelEnd, this);
        }
    }
}
