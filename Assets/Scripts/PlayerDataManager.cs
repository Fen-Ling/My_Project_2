using UnityEngine;
using System.IO;

public static class PlayerDataManager
{
    public static PlayerData playerData;

    public static void SavePlayerData(string filename, GameObject player)
    {
        var playerLevel = player.GetComponent<Player_Lvl>();
        var playerHealth = player.GetComponent<Player_HP>();

        playerData = new PlayerData()
        {
            level = playerLevel.currentLvl,
            curExp = playerLevel.currentExp,
            ExpToLvl = playerLevel.expForNewLVL,
            MaxHP = playerHealth.MaxHP,
            position = player.transform.position
        };

        string filepath = Path.Combine(Application.persistentDataPath, filename);
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

            // Получаем компоненты Player_Lvl и Player_HP
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var playerLevel = player.GetComponent<Player_Lvl>();
            var playerHealth = player.GetComponent<Player_HP>();

            // Обновляем значения компонентов
            playerLevel.currentLvl = playerData.level;
            playerLevel.currentExp = playerData.curExp;
            playerLevel.expForNewLVL = playerData.ExpToLvl;
            playerHealth.MaxHP = playerData.MaxHP;

            // Перемещаем игрока в загруженные координаты
            player.transform.position = playerData.position;




            Debug.Log($"Уровень: {playerData.level}, Опыт: {playerData.curExp}, Опыта до след. уровня: {playerData.ExpToLvl}, Макс. НР: {playerData.MaxHP}, Координаты: {playerData.position}");
            return true;
        }
        else
        {
            Debug.Log("Файл c данными игрока не найден.");
            return false;
        }
    }
}