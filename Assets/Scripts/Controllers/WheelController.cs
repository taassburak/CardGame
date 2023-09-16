using System;
using System.Collections;
using System.Collections.Generic;
using Script.Behaviours;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] List<WheelBehaviour> _wheelBehaviours;

    private GameManager _gameManager;

    private WheelBehaviour _currentWheelBehaviour;

    public event Action<WheelBehaviour,Action, Action> OnWheelSpinStarted;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        SetActiveWheelBehaviour();

        _gameManager.ZoneManager.OnZoneCompleted += SetActiveWheelBehaviour;
        _gameManager.ZoneManager.OnZoneReset += SetActiveWheelBehaviour;

    }

    private void OnDestroy()
    {
        _gameManager.ZoneManager.OnZoneCompleted -= SetActiveWheelBehaviour;
        _gameManager.ZoneManager.OnZoneReset -= SetActiveWheelBehaviour;
    }

    private void SetActiveWheelBehaviour()
    {
        if (ProjectData.CurrentZoneIndex % 10 == 0)
        {
            _currentWheelBehaviour = _wheelBehaviours[2];
        }
        else if (ProjectData.CurrentZoneIndex % 5 == 0)
        {
            _currentWheelBehaviour = _wheelBehaviours[1];
        }
        else
        {
            _currentWheelBehaviour = _wheelBehaviours[0];
        }

        for (int i = 0; i < _wheelBehaviours.Count; i++)
        {
            _wheelBehaviours[i].gameObject.SetActive(false);
        }

        _currentWheelBehaviour.gameObject.SetActive(true);

    }

    //for button
    public void StartWheeling()
    {
        //_currentWheelBehaviour.StartRotateWheel(_gameManager.ZoneManager.InvokeZoneCompleted, _gameManager.ZoneManager.InvokeZoneReset);
        OnWheelSpinStarted?.Invoke(_currentWheelBehaviour,_gameManager.ZoneManager.InvokeZoneCompleted, _gameManager.ZoneManager.InvokeZoneReset);
    }




}
