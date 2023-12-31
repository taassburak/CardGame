using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectData
{
    public static int CurrentZoneIndex
    {
        get => PlayerPrefs.GetInt("CurrentZoneIndex", 1);
        set
        {
            PlayerPrefs.SetInt("CurrentZoneIndex", value);
        }
    }

    public static string GainedWheelRewards
    {
        get => PlayerPrefs.GetString("GainedWheelRewards", "");
        set
        {
            PlayerPrefs.SetString("GainedWheelRewards", value);
        }
    }

    public static string GainedCaseReward
    {
        get => PlayerPrefs.GetString("GainedCaseReward", "");
        set
        {
            PlayerPrefs.SetString("GainedCaseReward", value);
        }
    }

    public static int ZoneId
    {
        get => PlayerPrefs.GetInt("ZoneId", 1);
        set
        {
            PlayerPrefs.SetInt("ZoneId", value);
        }
    }
}
