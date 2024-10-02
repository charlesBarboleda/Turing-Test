using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Health _playerHealth;
    [SerializeField] TextMeshProUGUI _textHealth;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] TextMeshProUGUI _level0ButtonPadText, _level1ButtonPadText;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.SetActive(false);
    }

    void OnEnable()
    {
        // Subscriptions
        _playerHealth.OnHealthUpdated += OnHealthUpdate;
        _playerHealth.OnDeath += OnDeath;

    }


    void OnDestroy()
    {
        // Unsubscriptions
        _playerHealth.OnHealthUpdated -= OnHealthUpdate;
        _playerHealth.OnDeath -= OnDeath;
    }

    void OnHealthUpdate(float health)
    {
        _textHealth.text = Mathf.Floor(health).ToString();
    }
    void OnDeath()
    {
        _gameOverText.SetActive(true);
    }

    public void UnlockLevel0ButtonPad()
    {
        _level0ButtonPadText.text = "UNLOCKED";
    }

    public void UnlockLevel1ButtonPad()
    {
        _level1ButtonPadText.text = "UNLOCKED";
    }
}
