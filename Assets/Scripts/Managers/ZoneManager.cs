using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZoneManager : MonoBehaviour
{

    public event Action OnZoneCompleted;
    public event Action OnZoneReset;
    public void Initialize()
    {
        OnZoneReset += ZoneReset;
    }

    private void ZoneCompleted()
    {
        ProjectData.CurrentZoneIndex++;
    }

    private void ZoneReset()
    {
        OnZoneReset -= ZoneReset;
        ProjectData.CurrentZoneIndex = 1;
        OnZoneReset += ZoneReset;
    }

    public void InvokeZoneCompleted()
    {
        ZoneCompleted();
        OnZoneCompleted?.Invoke();
    }

    public void InvokeZoneReset()
    {
        OnZoneReset?.Invoke();
    }

}
