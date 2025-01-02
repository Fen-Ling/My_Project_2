using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public static class PlayerDataManager
{
    public static PlayerData playerData;



    public static void SavePlayerData(string filename, GameObject player)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);
        var playerLevel = player.GetComponent<Player_Lvl>();
        var playerHealth = player.GetComponent<Player_HP>();
        var playerLoader = player.GetComponentInParent<CharacterLoader>();

        playerData = new PlayerData()
        {
            genderIndex = playerLoader.genderIndex,
            classIndex = playerLoader.classIndex,
            level = playerLevel.currentLvl,
            curExp = playerLevel.currentExp,
            ExpToLvl = playerLevel.expForNewLVL,
            MaxHP = playerHealth.MaxHP,
            position = player.transform.position
        };

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(filepath, json);
        Debug.Log("Данные игрока сохранены в файл!");
        Debug.Log($"Уровень: {playerData.level}, Опыт: {playerData.curExp}, Опыта до след. уровня: {playerData.ExpToLvl}, Макс. НР: {playerData.MaxHP}, Координаты: {playerData.position}");
    }

    public static bool LoadPlayerData(string filename)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Данные игрока загружены!");

            return true;
        }
        else
        {
            Debug.Log("Файл c данными игрока не найден.");
            return false;
        }
    }

    public static void NewGame_PlayerData(int genderIndex, int classIndex)
    {
        playerData = new PlayerData()
        {
            genderIndex = genderIndex,
            classIndex = classIndex,
            level = 1,
            curExp = 0,
            ExpToLvl = 100,
            MaxHP = 200,
            position = new Vector3(192, 56, 54)
        };
    }
}