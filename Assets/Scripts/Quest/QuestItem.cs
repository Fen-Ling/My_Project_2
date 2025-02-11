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
    private int questProgress;
    private int questProgressEnd;


    public void Start()
    {
        questState = QuestState.Available;
        var quest = QuestDataManager.FindQuestByName(questNameText.text);
        questProgress = quest.QuestProgressStart;
        questProgressEnd = quest.QuestProgressEnd;
        questText.text = "Прогресс:" + questProgress + "из" + questProgressEnd;
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
        if (questProgress == questProgressEnd)
        {
            questState = QuestState.Completed;
            QuestDataManager.UpdateQuestByName(questNameText.text, true);
            Debug.Log("Квест " + questNameText.text + " завершен!");
            gameObject.SetActive(false);
        }
        else
            Debug.Log("Квест " + questNameText.text + "не завершен!");
    }

    public void ProgressQuest(int progress)
    {
        questProgress += progress;
        questProgress = Mathf.Clamp(questProgress, 0, questProgressEnd);
        questText.text = "Прогресс:" + questProgress + "из" + questProgressEnd;
    }
}