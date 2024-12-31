using UnityEngine;
using System.IO;

public static class PlayerDataManager
{
    public static PlayerData playerData = new();

    public static void SavePlayerData(string filename)//int level, int currentExperience, float money, Vector3 position)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);
        // playerData = new PlayerData()
        // {
        //     level = level,
        //     currentExperience = currentExperience,
        //     money = money,
        //     position = position
        // };

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filepath, json);
        Debug.Log("Данные игрока сохранены в файл!");
    }

    public static bool LoadPlayerData(string filename)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Данные игрока загружены!");
            Debug.Log($"Уровень: {playerData.level}, Опыт: {playerData.currentExperience}, Деньги: {playerData.money}, Координаты: {playerData.position}");
            return true;
        }
        else
        {
            Debug.Log("Файл c данными игрока не найден.");
            return false;
        }
    }
}