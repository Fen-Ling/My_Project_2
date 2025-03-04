using UnityEngine;
using System.IO;

public static class SettingsDataManager
{
    public static Settings_Data SettingData;

    public static void SaveSettings(Settings_Data settings)
    {
        var settingsFilePath = Path.Combine(Application.persistentDataPath, "settings.json");
        string json = JsonUtility.ToJson(settings, true);
        File.WriteAllText(settingsFilePath, json);
        SettingData = settings;
        Debug.Log("Настройки сохранены: " + settingsFilePath);
    }

    public static Settings_Data LoadSettings()
    {
        var settingsFilePath = Path.Combine(Application.persistentDataPath, "settings.json");
        
        if (File.Exists(settingsFilePath))
        {
            string json = File.ReadAllText(settingsFilePath);
            SettingData = JsonUtility.FromJson<Settings_Data>(json);
            Debug.Log("Настройки загружены: " + settingsFilePath);
        }
        else
        {
            Debug.LogWarning("Файл настроек не найден! Используются настройки по умолчанию.");
            DefaultSettings();
        }
        return SettingData;
    }

    public static Settings_Data GetCurrentSettings()
    {
        return SettingData;
    }

    public static Settings_Data DefaultSettings()
    {
        SettingData = new Settings_Data()
        {
            volume = 1,
            width = 600,
            height = 800,
            isFullScreen = true,
        };
        return SettingData;
    }
}
