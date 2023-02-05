using UnityEngine;

public static class DataManager 
{
    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey, 0);
        set => PlayerPrefs.SetInt(PlayerPrefsKeys.CurrentLevelKey, value);
    }

    public static bool TestBool
    {
        get => PlayerPrefs.GetInt(PlayerPrefsKeys.TestBoolKey, 0) != 0;
        set => PlayerPrefs.SetInt(PlayerPrefsKeys.TestBoolKey, value ? 1 : 0);
    }
}

public struct PlayerPrefsKeys
{
    public const string CurrentLevelKey = "CurrentLevel";
    public const string TestBoolKey = "TestBool";
}
