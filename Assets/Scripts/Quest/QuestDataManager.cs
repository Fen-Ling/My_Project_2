using System.IO;
using UnityEngine;

public static class QuestDataManager
{
    private static QuestDataList questDataList = new QuestDataList();

    public static void AddQuestData(int questID, string questName, string questInfo, int questProgressStart, int questProgressEnd, bool questComplete)
    {
        string filepath = Path.Combine(Application.dataPath, "QuestData.json");

        LoadQuestData();

        QuestData newQuest = new QuestData()
        {
            QuestID = questID,
            QuestName = questName,
            QuestInfo = questInfo,
            QuestProgressStart = questProgressStart,
            QuestProgressEnd = questProgressEnd,
            QuestComplete = questComplete,
        };

        questDataList.quests.Add(newQuest);

        string json = JsonUtility.ToJson(questDataList, true);
        File.WriteAllText(filepath, json);
        Debug.Log("Данные квеста сохранены в файл!");
        Debug.Log($"ID квеста: {newQuest.QuestID}, Название: {newQuest.QuestName}");
    }

    public static bool LoadQuestData()
    {
        string filepath = Path.Combine(Application.dataPath, "QuestData.json");

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            questDataList = JsonUtility.FromJson<QuestDataList>(json);
            return true;
        }
        else
        {
            Debug.Log("Файл c данными квестов не найден.");
            return false;
        }
    }

    public static void ResetQuestData()
    {
        string filepath = Path.Combine(Application.dataPath, "QuestData.json");
        if (LoadQuestData())
        {
            // Проходим по всем квестам и сбрасываем статус завершенности
            foreach (var quest in questDataList.quests)
            {
                if (quest.QuestComplete)
                {
                    quest.QuestComplete = false;
                    Debug.Log($"Квест сброшен: ID = {quest.QuestID}, Название = {quest.QuestName}");
                }
            }

            string json = JsonUtility.ToJson(questDataList, true);
            File.WriteAllText(filepath, json);
            Debug.Log("Все завершенные квесты сброшены на незавершенные.");
        }
        else
        {
            Debug.Log("Не удалось загрузить данные квестов для сброса.");
        }
    }

    public static void SaveQuestDataPlayer(string filename)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);

        LoadQuestData();
        string json = JsonUtility.ToJson(questDataList, true);
        File.WriteAllText(filepath, json);
        Debug.Log("Данные квестов сохранены в файл!");

    }

    public static bool LoadQuestDataPlayer(string filename)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            questDataList = JsonUtility.FromJson<QuestDataList>(json);
            Debug.Log("Данные квестов игрока загружены!");

            string savePath = Path.Combine(Application.dataPath, "QuestData.json");
            string saveJson = JsonUtility.ToJson(questDataList, true);
            File.WriteAllText(savePath, saveJson);
            Debug.Log("Данные о квестах сохранены в QuestData.json");

            return true;
        }
        else
        {
            Debug.Log("Файл c квестами игрока не найден^" + filename);
            return false;
        }
    }

    public static void DeleteQuestDataPlayer(string filename)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filename);

        if (File.Exists(filepath))
        {
            File.Delete(filepath);
            Debug.Log("Данные квестов удалены!");
        }
        else
        {
            Debug.Log("Файл c данными квестов игрока не найден.");
        }
    }

    public static QuestData FindQuestByID(int questID)
    {
        LoadQuestData();
        foreach (var quest in questDataList.quests)
        {
            if (quest.QuestID == questID)
            {
                Debug.Log($"Квест найден: ID = {quest.QuestID}, Название = {quest.QuestName}");
                return quest;
            }
        }

        Debug.Log("Квест не найден.");
        return null;
    }

    public static QuestData FindQuestByName(string questName)
    {
        LoadQuestData();
        foreach (var quest in questDataList.quests)
        {
            if (quest.QuestName.Equals(questName, System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log($"Квест найден: ID = {quest.QuestID}, Название = {quest.QuestName}");
                return quest;
            }
        }

        Debug.Log("Квест не найден.");
        return null;
    }

    public static void UpdateQuestByName(string questName, bool questComplete)
    {
        LoadQuestData();
        QuestData questToUpdate = FindQuestByName(questName);
        if (questToUpdate != null)
        {
            questToUpdate.QuestComplete = questComplete;

            string json = JsonUtility.ToJson(questDataList, true);
            string filepath = Path.Combine(Application.dataPath, "QuestData.json");
            File.WriteAllText(filepath, json);
            Debug.Log($"Статус завершения квеста обновлен: ID = {questToUpdate.QuestID}, Завершен = {questToUpdate.QuestComplete}");
        }
        else
        {
            Debug.Log("Не удалось обновить статус завершения квеста. Квест не найден.");
        }
    }
}
