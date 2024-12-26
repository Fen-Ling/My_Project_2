using UnityEngine;
using System.IO;

public class PlayerDataManager : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
    }

    public void SavePlayerData(int level, int currentExperience, float money, Vector3 position)
    {
        PlayerData playerData = new PlayerData()
        {
            level = level,
            currentExperience = currentExperience,
            money = money,
            position = position
        };

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Данные игрока сохранены в файл!");
    }

    public void LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Данные игрока загружены!");
            Debug.Log($"Уровень: {loadedData.level}, Опыт: {loadedData.currentExperience}, Деньги: {loadedData.money}, Координаты: {loadedData.position}");
        }
        else
        {
            Debug.Log("Файл c данными игрока не найден.");
        }
    }
}