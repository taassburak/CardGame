using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WheelController WheelController => _wheelController;
    public ZoneManager ZoneManager => _zoneManager;
    public BackPackConfig BackPackConfig => _backPackConfig;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private WheelController _wheelController;
    [SerializeField] private ZoneManager _zoneManager;

    [SerializeField] BackPackConfig _backPackConfig;
    void Start()
    {
        BackPack.Initialize();
        BackPack.Instance.SoftInitialize(this);
        _zoneManager.Initialize();
        _uiManager.Initialize(this);
        _wheelController.Initialize(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button] //for button
    public void SaveBackPack()
    {
        BackPack.Instance.AddItemToPermanentBackPack();
        _zoneManager.InvokeZoneReset();
    }
}
