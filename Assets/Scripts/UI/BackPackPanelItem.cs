using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackPanelItem : MonoBehaviour
{
    public WheelRewardType RewardType => _rewardType;
    public int Quantity;
    [SerializeField] private WheelRewardType _rewardType;
    [SerializeField] private Text _quantityText;


    public void Populate(int amount)
    {
        Quantity = amount;
        _quantityText.text = $"{amount}x";
    }
}
