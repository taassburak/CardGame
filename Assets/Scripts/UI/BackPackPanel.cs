using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackPackPanel : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;

    [SerializeField] private List<BackPackPanelItem> _backPackPanelItems;

    private void ShowPanel()
    {

    }

    private void HidePanel()
    {

    }

    [Button]
    private void PopulatePanel()
    {
        for (int i = 0; i < _backPackPanelItems.Count; i++)
        {
            _backPackPanelItems[i].gameObject.SetActive(true);

            var configItem = _gameManager.BackPackConfig.BackPackItemDatasContainer.BackPackItemDatas.Find(x => x.WheelRewardType == _backPackPanelItems[i].RewardType);

            _backPackPanelItems[i].Populate(configItem.TemporaryQuantity);

            if (_backPackPanelItems[i].Quantity == 0)
            {
                _backPackPanelItems[i].gameObject.SetActive(false);
            }
            
        }

        var newList = _backPackPanelItems.OrderBy(x=>x.Quantity).ToList();

        for (int i = 0; i < newList.Count; i++)
        {
            newList[i].transform.SetSiblingIndex((newList.Count - 1) - i);
        }
    }
}
