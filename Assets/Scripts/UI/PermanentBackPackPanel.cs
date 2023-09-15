using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PermanentBackPackPanel : MonoBehaviour
{

    private UiManager _uiManager;

    [SerializeField] private List<BackPackPanelItem> _backPackPanelItems;

    public void Initialize(UiManager uiManager)
    {
        _uiManager = uiManager;
    }


    public void ShowPanel()
    {
        gameObject.SetActive(true);
        PopulatePanel();
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    

    [Button]
    private void PopulatePanel()
    {
        for (int i = 0; i < _backPackPanelItems.Count; i++)
        {
            _backPackPanelItems[i].gameObject.SetActive(true);

            var configItem = _uiManager.GameManager.BackPackConfig.BackPackItemDatasContainer.BackPackItemDatas.Find(x => x.WheelRewardType == _backPackPanelItems[i].RewardType);

            _backPackPanelItems[i].Populate(configItem.PermanentQuantity);

            if (_backPackPanelItems[i].Quantity == 0)
            {
                _backPackPanelItems[i].gameObject.SetActive(false);
            }

        }

        var newList = _backPackPanelItems.OrderBy(x => x.Quantity).ToList();

        for (int i = 0; i < newList.Count; i++)
        {
            newList[i].transform.SetSiblingIndex((newList.Count - 1) - i);
        }
    }
}
