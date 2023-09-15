using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackPanel : MonoBehaviour
{
    public UiManager UiManager => _uiManager;
    [SerializeField] private PermanentBackPackPanel _permanentBackPackPanel;
    [SerializeField] private TemporaryBackPackPanel _temporarayBackPackPanel;
    private UiManager _uiManager;

    public void Initialize(UiManager uiManager)
    {
        _uiManager = uiManager;
        _permanentBackPackPanel.Initialize(_uiManager);
        _temporarayBackPackPanel.Initialize(_uiManager);
    }

    public void ShowPanel(bool isTmpBackPackPanel)
    {
        if (isTmpBackPackPanel)
        {
            _temporarayBackPackPanel.ShowPanel();
        }
        else
        {
            _permanentBackPackPanel.ShowPanel();
        }
    }
}
