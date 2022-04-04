using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScreen : MonoBehaviour
{
    [SerializeField] private LevelButton[] levelButtons;
    
    private void OnEnable()
    {
        foreach (var levelButton in levelButtons)
        {
            levelButton.Button.onClick.AddListener(levelButton.LoadLevel);
        }
    }

    private void OnDisable()
    {
        foreach (var levelButton in levelButtons)
        {
            levelButton.Button.onClick.RemoveListener(levelButton.LoadLevel);
        }
    }
}
