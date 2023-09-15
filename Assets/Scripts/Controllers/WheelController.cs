using System.Collections;
using System.Collections.Generic;
using Script.Behaviours;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] List<WheelBehaviour> _wheelBehaviours;

    private GameManager _gameManager;

    private WheelBehaviour _currentWheelBehaviour;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
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

    }

    //for button
    public void StartWheeling()
    { 
        _currentWheelBehaviour.StartRotateWheel(_gameManager.ZoneManager.InvokeZoneCompleted);
    }




}
