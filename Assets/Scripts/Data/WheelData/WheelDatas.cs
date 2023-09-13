using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WheelRewardType 
{
    Money,
    Gold,
    Case1,
    Case2,
    Case3,
    Case4,
    Case5,
    Bomb
}

[Serializable]
public class WheelDataContainer
{
    public List<WheelItemData> WheelDatas;
    public WheelDataContainer()
    {
        WheelDatas = new List<WheelItemData>();
    }
}

[CreateAssetMenu(fileName = "WheelData", menuName = "WheelData")]
public class WheelDatas : ScriptableObject
{
    public WheelDataContainer WheelDataContainers;
    public WheelItemData BombItem;
}
