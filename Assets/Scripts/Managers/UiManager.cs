using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameManager GameManager => _gameManager;
    private GameManager _gameManager;

    [SerializeField] private BackPackPanel _backPackPanel;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _backPackPanel.Initialize(this);
    }
    
}
