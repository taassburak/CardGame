using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WheelItem : MonoBehaviour
{
   

    [SerializeField] private Image _image;
    [SerializeField] private WheelRewardType _wheelRewardType;
    [SerializeField] private WheelItemData _wheelItemData;
    public void PopulateItem(WheelItemData wheelItemData,Sprite sprite, WheelRewardType wheelPrizeType)
    {
        _wheelItemData = wheelItemData;
        _wheelRewardType = wheelPrizeType;
        _image.sprite = sprite;
    }

    public WheelRewardType GetRewardType()
    {
        return _wheelRewardType;
    }

    public WheelItemData GetWheelItemData()
    {
        return _wheelItemData;
    }
}
