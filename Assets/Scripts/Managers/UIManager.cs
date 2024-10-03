using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverText;
    [SerializeField] TextMeshProUGUI _level0ButtonPadText, _level1ButtonPadText;

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
}
