
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace Script.Behaviours
{

    public class WheelBehaviour : MonoBehaviour
    {
        [SerializeField] private WheelDatas _wheelDatas;
        [SerializeField] private List<WheelItem> _slots;

        [Button]
        public void StartRotateWheel()
        {
            //BackPack.Initialize();
            var randomIndex = Random.Range(0, 8);

            var pieceAngleValue = 360 / 8;

            var endValue = new Vector3(0, 0, (360 * 8) + (pieceAngleValue * randomIndex));

            transform.DORotate(endValue, 3f).SetRelative(true).OnComplete(() =>
            {
                Debug.Log($"Taken reward is : {_slots[randomIndex].GetRewardType()}");

                if (_slots[randomIndex].GetRewardType() != WheelRewardType.Bomb)
                {
                    BackPack.Instance.AddItem(_slots[randomIndex]);
                    for (int i = 0; i < BackPack.Instance.GetItems().Count; i++)
                    {
                        Debug.Log($"item: {BackPack.Instance.GetItems()[i].WheelRewardType} Quantity: {BackPack.Instance.GetItems()[i].Quantity}");
                    }
                }
                else
                {
                    BackPack.Instance.ClearItems();
                }

            });
        }


        [Button]
        public void PopulateSlots()
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                var sprite = _wheelDatas.WheelDataContainers.WheelDatas[i].WheelItemDataContainer.Texture;
                var prizeType = _wheelDatas.WheelDataContainers.WheelDatas[i].WheelItemDataContainer.WheelRewardType;
                _slots[i].PopulateItem(_wheelDatas.WheelDataContainers.WheelDatas[i],sprite, prizeType);
            }
            var randomBombIndex = Random.Range(0, 8);
            var bombSprite = _wheelDatas.BombItem.WheelItemDataContainer.Texture;
            var bombPrizeType = _wheelDatas.BombItem.WheelItemDataContainer.WheelRewardType;
            _slots[randomBombIndex].PopulateItem(_wheelDatas.WheelDataContainers.WheelDatas[randomBombIndex], bombSprite, bombPrizeType);
        }
    }
}