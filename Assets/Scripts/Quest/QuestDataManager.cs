using System.IO;
using UnityEngine;

public static class QuestDataManager
{
    private static QuestDataList questDataList = new QuestDataList();

    public static void AddQuestData(int questID, string questName, string questInfo, int questProgressStart, int questProgressEnd, bool questComplete)
    {
        string filepath = Path.Combine(Application.persistentDataPath, "QuestData.json");

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
        string filepath = Path.Combine(Application.persistentDataPath, "QuestData.json");

        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            questDataList = JsonUtility.FromJson<QuestDataList>(json);
            Debug.Log("Данные квестов загружены!");

            return true;
        }
        else
        {
            Debug.Log("Файл c данными квестов не найден.");
            return false;
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
            string filepath = Path.Combine(Application.persistentDataPath, "QuestData.json");
            File.WriteAllText(filepath, json);
            Debug.Log($"Статус завершения квеста обновлен: ID = {questToUpdate.QuestID}, Завершен = {questToUpdate.QuestComplete}");
        }
        else
        {
            Debug.Log("Не удалось обновить статус завершения квеста. Квест не найден.");
        }
    }
}
