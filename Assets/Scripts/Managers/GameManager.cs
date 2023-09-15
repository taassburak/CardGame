using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        _uiManager.Initialize(this);
        _wheelController.Initialize(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    private void SaveBackPackTest()
    {
        BackPack.Instance.AddItemToPermanentBackPack();
    }
}
