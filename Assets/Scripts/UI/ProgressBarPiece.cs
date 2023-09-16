using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPiece : MonoBehaviour
{

    public Image Image => _imageComponent;

    [SerializeField] private Text _text;
    [SerializeField] private Image _imageComponent;
    private int _currentZoneIndex;

    public void Initialize(int initialZoneIndex)
    {
        _currentZoneIndex = initialZoneIndex;
    }

    public void SetPieceSprite(Sprite normalPieceSprite, Sprite specialPieceSprite)
    {
        
        if (_currentZoneIndex % 5 == 0)
        {
            _imageComponent.sprite = specialPieceSprite;
        }
        else
        {
            _imageComponent.sprite = normalPieceSprite;
        }
    }

    public void IncreaseCurrentZoneIndex()
    {
        _currentZoneIndex++;
        SetText(_currentZoneIndex);
    }

    public void SetText(int index)
    {
        _text.text = index.ToString();

    }

}
