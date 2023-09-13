using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WheelItemDataContainer
{
    public WheelRewardType WheelRewardType;
    public int PrizeMultiplier;
    public Sprite Texture;
}


[CreateAssetMenu(fileName = "WheelItemData", menuName = "WheelItemData")]
public class WheelItemData : ScriptableObject
{
    public WheelItemDataContainer WheelItemDataContainer;
}
