using TMPro;
using UnityEngine;

public enum QuestState
{
    Available,
    Active,
    Completed
}

public class QuestItem : MonoBehaviour
{
    public TMP_Text questNameText;
    public TMP_Text questText;
    public QuestState questState;


    public void Awake()
    {
        questState = QuestState.Available;

    }
    public void SetQuestName(string questName)
    {
        if (questNameText != null && questState != QuestState.Completed)
        {
            questNameText.text = questName; // Устанавливаем текст названия квеста
            questState = QuestState.Active;
        }
        else
            gameObject.SetActive(false);
    }

    public void CompleteQuest()
    {
        // Логика завершения квеста (например, обновление статуса, награды и т.д.)
        questState = QuestState.Completed;
        QuestDataManager.UpdateQuestByName(questNameText.text, true);
        Debug.Log("Квест " + questNameText.text + " завершен!");
        gameObject.SetActive(false);
    }

    public void ProgressQuest()
    {

    }
}