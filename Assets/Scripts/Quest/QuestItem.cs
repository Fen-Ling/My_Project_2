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

    public void Start()
    {
        questState = QuestState.Available;
    }
    public void SetQuestName(string questName)
    {
        if (questNameText != null)
        {
            questNameText.text = questName; // Устанавливаем текст названия квеста
            questState = QuestState.Active;
        }
        
    }

    public void CompleteQuest()
    {
        // Логика завершения квеста (например, обновление статуса, награды и т.д.)
        questState = QuestState.Completed;
        
        Debug.Log("Квест " + questNameText.text + " завершен!");
        Destroy(gameObject, 1f); // Удаляем объект квеста из сцены
    }
}