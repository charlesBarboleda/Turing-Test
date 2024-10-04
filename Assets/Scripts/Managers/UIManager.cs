using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] GameObject _gameOverText;
    [SerializeField] TextMeshProUGUI _level0ButtonPadText, _level1ButtonPadText, _pressToInteractText;
    [SerializeField] TextMeshProUGUI _congratsText;
    [SerializeField] Image _whiteFadeImage;

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

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.SetActive(false);
    }


    public void UnlockLevel0ButtonPad()
    {
        _level0ButtonPadText.text = "UNLOCKED";
    }

    public void UnlockLevel1ButtonPad()
    {
        _level1ButtonPadText.text = "UNLOCKED";
    }

    public IEnumerator GameOverScreen()
    {
        float opacity = 0;

        while (opacity < 2)
        {
            opacity += Time.deltaTime;
            _whiteFadeImage.color = new Color(1, 1, 1, opacity);
            yield return null;
        }
        _congratsText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverScreen());
    }

    public void PressEHover()
    {
        _pressToInteractText.gameObject.SetActive(true);
    }

    public void PressEHoverExit()
    {
        _pressToInteractText.gameObject.SetActive(false);
    }
}
