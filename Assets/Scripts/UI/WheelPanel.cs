using Script.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelPanel : MonoBehaviour
{

    private UiManager _uiManager;
    [SerializeField] private List<WheelBehaviour> _wheelBehaviours;
    [SerializeField] private Button _spinButton;
    [SerializeField] private Button _takeRewardsButton;
    public void Initialize(UiManager uiManager)
    {
        _uiManager = uiManager;
        foreach (var wheel in _wheelBehaviours)
        {
            wheel.Initialize(_uiManager);
        }

        _uiManager.GameManager.WheelController.OnWheelSpinStarted += StartWheeling;
    }

    private void StartWheeling(WheelBehaviour wheelBehaviour, Action successAction, Action failAction)
    {
        _uiManager.GameManager.WheelController.OnWheelSpinStarted -= StartWheeling;
        SetButtons(false);
        
        wheelBehaviour.StartRotateWheel(successAction, failAction);

        _uiManager.GameManager.WheelController.OnWheelSpinStarted += StartWheeling;

    }

    public void SetButtons(bool isActive)
    {
        _takeRewardsButton.gameObject.SetActive(isActive);
        _spinButton.gameObject.SetActive(isActive);
    }

}
