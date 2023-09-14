using DG.Tweening.Core.Easing;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.RestService;
using UnityEngine;

[Serializable]
public class BackPackItemDatas
{
    public WheelRewardType WheelRewardType;
    public int TemporaryQuantity;
    public int PermanentQuantity;

    public BackPackItemDatas(WheelRewardType wheelRewardType, int quantity)
    {
        WheelRewardType = wheelRewardType;
        TemporaryQuantity = quantity;
    }

}

[Serializable]
public class BackPackItemDatasContainer
{
    public List<BackPackItemDatas> BackPackItemDatas;
    public BackPackItemDatasContainer()
    {
        BackPackItemDatas = new List<BackPackItemDatas>();
    }
}

public class BackPack
{
    public static BackPack Instance;
    private BackPackItemDatasContainer _backPackItemDatasContainer;
    private BackPackConfig _backPackConfig;

    public void SoftInitialize(GameManager gameManager)
    {
        _backPackConfig = gameManager.BackPackConfig;
        InitialSave(gameManager.BackPackConfig);
    }

    public static void Initialize()
    {
        Instance = new BackPack();
    }

    public void AddItemToPermanentBackPack()
    {
        for (int i = 0; i < _backPackItemDatasContainer.BackPackItemDatas.Count; i++)
        {
            _backPackItemDatasContainer.BackPackItemDatas[i].PermanentQuantity += _backPackItemDatasContainer.BackPackItemDatas[i].TemporaryQuantity;
            _backPackItemDatasContainer.BackPackItemDatas[i].TemporaryQuantity = 0;
        }

        SaveBackPack();
    }

    public void AddItemToTempBackPack(WheelItem wheelItem)
    {
        for (int i = 0; i < _backPackItemDatasContainer.BackPackItemDatas.Count; i++)
        {
            if (wheelItem.GetWheelItemData().WheelItemDataContainer.WheelRewardType == _backPackItemDatasContainer.BackPackItemDatas[i].WheelRewardType)
            {
                _backPackItemDatasContainer.BackPackItemDatas[i].TemporaryQuantity++;
                SaveBackPack();
                return;
            }
        }

        var newItem = new BackPackItemDatas(wheelItem.GetWheelItemData().WheelItemDataContainer.WheelRewardType, 1);
        _backPackItemDatasContainer.BackPackItemDatas.Add(newItem);
        SaveBackPack();
    }

    public void ClearItems()
    {
        for (int i = 0; i < _backPackConfig.BackPackItemDatasContainer.BackPackItemDatas.Count; i++)
        {
            _backPackConfig.BackPackItemDatasContainer.BackPackItemDatas[i].TemporaryQuantity = 0;
        }

        SaveBackPack();
    }

    public List<BackPackItemDatas> GetItems()
    {
        return _backPackItemDatasContainer.BackPackItemDatas;
    }
   
    private void InitialSave(BackPackConfig backPackConfig)
    {
        string saveDataJson = ProjectData.GainedWheelRewards;

        if (saveDataJson == "" || saveDataJson == null)
        {
            var newData = new BackPackItemDatasContainer();

            for (int i = 0; i < backPackConfig.BackPackItemDatasContainer.BackPackItemDatas.Count; i++)
            {
                newData.BackPackItemDatas.Add(backPackConfig.BackPackItemDatasContainer.BackPackItemDatas[i]);
            }

            string saveJson = JsonUtility.ToJson(newData);
            ProjectData.GainedWheelRewards = saveJson;
            saveDataJson = ProjectData.GainedWheelRewards;

            _backPackItemDatasContainer = JsonUtility.FromJson<BackPackItemDatasContainer>(saveDataJson);
        }
        else
        {
            _backPackItemDatasContainer = JsonUtility.FromJson<BackPackItemDatasContainer>(saveDataJson);
        }


        PopulateBackPackConfig(backPackConfig);

    }

    private void PopulateBackPackConfig(BackPackConfig backPackConfig)
    {
        for (int i = 0; i < _backPackItemDatasContainer.BackPackItemDatas.Count; i++)
        {
            backPackConfig.BackPackItemDatasContainer.BackPackItemDatas[i].TemporaryQuantity = _backPackItemDatasContainer.BackPackItemDatas[i].TemporaryQuantity;
            backPackConfig.BackPackItemDatasContainer.BackPackItemDatas[i].PermanentQuantity = _backPackItemDatasContainer.BackPackItemDatas[i].PermanentQuantity;

        }
    }

    private void SaveBackPack()
    {
        //string saveData = ProjectData.GainedWheelRewards;

        //_backPackItemDatasContainer = JsonUtility.FromJson<BackPackItemDatasContainer>(saveData);

        string saveJson = JsonUtility.ToJson(_backPackItemDatasContainer);

        ProjectData.GainedWheelRewards = saveJson;

        PopulateBackPackConfig(_backPackConfig);
    }
}
