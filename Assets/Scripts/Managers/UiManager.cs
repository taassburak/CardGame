using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public WheelPanel WheelPanel => _wheelPanel;
    public GameManager GameManager => _gameManager;

    [SerializeField] private BackPackPanel _backPackPanel;
    [SerializeField] private ZoneProgressPanel _zoneProgressPanel;
    [SerializeField] private WheelPanel _wheelPanel;
    private GameManager _gameManager;


    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _backPackPanel.Initialize(this);
        _zoneProgressPanel.Initialize(this);
        _wheelPanel.Initialize(this);
    }
    
}
