using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneProgressPanel : MonoBehaviour
{
    [SerializeField] private Sprite _currentZoneSprite;
    [SerializeField] private Sprite _specialZoneSprite;
    [SerializeField] private Sprite _normalZoneSprite;

    [SerializeField] private List<ProgressBarPiece> _zoneProgressBarPieces;

    private UiManager _uiManager;



    public void Initialize(UiManager uiManager)
    {
        _uiManager = uiManager;
        if (ProjectData.CurrentZoneIndex > 5)
        {
            var upperIndex = ProjectData.CurrentZoneIndex+1;
            var lowerIndex = ProjectData.CurrentZoneIndex+1;

            for (int i = 6; i < _zoneProgressBarPieces.Count; i++)
            {
                _zoneProgressBarPieces[i].Initialize(upperIndex);
                _zoneProgressBarPieces[i].SetPieceSprite(_normalZoneSprite, _specialZoneSprite);
                _zoneProgressBarPieces[i].SetText(upperIndex);
                upperIndex++;
            }
            for (int i = 5; i >= 0; i--)
            {
                lowerIndex--;
                _zoneProgressBarPieces[i].Initialize(lowerIndex);
                _zoneProgressBarPieces[i].SetPieceSprite(_normalZoneSprite, _specialZoneSprite);
                _zoneProgressBarPieces[i].SetText(lowerIndex);
            }
        }
        else
        {
            for (int i = 0; i < _zoneProgressBarPieces.Count; i++)
            {
                _zoneProgressBarPieces[i].Initialize(i + 1);
                _zoneProgressBarPieces[i].SetPieceSprite(_normalZoneSprite, _specialZoneSprite);
                _zoneProgressBarPieces[i].SetText(i + 1);
            }
        }

        var index = ProjectData.CurrentZoneIndex-1;
        var clampedIndex = Mathf.Clamp(index, 0, 5);
        _zoneProgressBarPieces[clampedIndex].Image.sprite = _currentZoneSprite;

        _uiManager.GameManager.ZoneManager.OnZoneCompleted += SetProgressBar;
        _uiManager.GameManager.ZoneManager.OnZoneReset += ResetProgressBar;


    }

    private void ResetProgressBar()
    {
        _uiManager.GameManager.ZoneManager.OnZoneReset -= ResetProgressBar;


        for (int i = 0; i < _zoneProgressBarPieces.Count; i++)
        {
            _zoneProgressBarPieces[i].Initialize(i + 1);
            _zoneProgressBarPieces[i].SetPieceSprite(_normalZoneSprite, _specialZoneSprite);
            _zoneProgressBarPieces[i].SetText(i + 1);
        }

        _uiManager.GameManager.ZoneManager.OnZoneReset += ResetProgressBar;

    }

    private void SetProgressBar()
    {
        _uiManager.GameManager.ZoneManager.OnZoneCompleted -= SetProgressBar;


        var index = ProjectData.CurrentZoneIndex-1;

        if (index > 5)
        {
            for (int i = 0; i < _zoneProgressBarPieces.Count; i++)
            {
                _zoneProgressBarPieces[i].IncreaseCurrentZoneIndex();
            }
        }


        for (int i = 0; i < _zoneProgressBarPieces.Count; i++)
        {
            _zoneProgressBarPieces[i].SetPieceSprite(_normalZoneSprite, _specialZoneSprite);

        }

        

        var clampedIndex = Mathf.Clamp(index, 0, 5);

        _zoneProgressBarPieces[clampedIndex].Image.sprite = _currentZoneSprite;

        _uiManager.GameManager.ZoneManager.OnZoneCompleted += SetProgressBar;

    }







}
