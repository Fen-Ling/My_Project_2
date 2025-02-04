using TMPro;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public TMP_Text questNameText;
    public TMP_Text questText;

    public void SetQuestName(string questName)
    {
        if (questNameText != null)
        {
            questNameText.text = questName; // Устанавливаем текст названия квеста
        }
    }

    public void CompleteQuest()
    {
        // Логика завершения квеста (например, обновление статуса, награды и т.д.)
        
        
        Debug.Log("Квест " + questNameText.text + " завершен!");

        Destroy(gameObject, 1f); // Удаляем объект квеста из сцены
    }
}