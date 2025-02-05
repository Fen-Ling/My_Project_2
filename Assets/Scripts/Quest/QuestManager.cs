using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject talkPrompt;
    public GameObject questUI;
    public GameObject questSelect;
    public GameObject questInfo;
    public GameObject acceptQuestButton;
    public GameObject completeQuestButton;

    public GameObject questSelectPrefab;
    public TMP_Text questDescriptionText;

    public GameObject questParent;
    public GameObject questPrefab;

    public List<QuestItem> acceptQuests = new List<QuestItem>();
    public List<QuestItem> activeQuests = new List<QuestItem>();

    private void Awake()
    {
        talkPrompt.SetActive(false);
        questUI.SetActive(false);
        acceptQuestButton.SetActive(false);
        completeQuestButton.SetActive(false);
    }

    public void ShowTalkPrompt()
    {
        talkPrompt.SetActive(true);
    }

    public void HideTalkPrompt()
    {
        talkPrompt.SetActive(false);
    }

    public void ShowQuestUI(string questDescription)
    {
        questDescriptionText.text = questDescription;
        questUI.SetActive(true);
        questSelect.SetActive(true);
        questInfo.SetActive(false);
    }

    public void QuestSelect()
    {
        questSelect.SetActive(false);
        questInfo.SetActive(true);

        string questName = questDescriptionText.text;
        QuestItem selectedQuest = FindQuestByName(questName);

        if (selectedQuest != null)
        {
            switch (selectedQuest.questState)
            {
                case QuestState.Active:
                    acceptQuestButton.SetActive(false);
                    completeQuestButton.SetActive(true);
                    break;
                case QuestState.Completed:
                    acceptQuestButton.SetActive(false);
                    completeQuestButton.SetActive(false);
                    break;
            }
        }
        else
        {
            acceptQuestButton.SetActive(true);
            completeQuestButton.SetActive(false);
        }
    }

    public void AcceptQuest()
    {
        string questName = questDescriptionText.text;

        if (FindQuestByName(questName))
        {
            Debug.Log("Квест с таким именем уже существует!");
            return;
        }

        Debug.Log("Квест принят!");
        GameObject questObject = Instantiate(questPrefab, questParent.transform);
        QuestItem questItem = questObject.GetComponent<QuestItem>();


        if (questItem != null)
        {
            questItem.SetQuestName(questName); // Устанавливаем название квеста
            AddQuestActive(questItem); // Добавляем квест в активные
        }

        questUI.SetActive(false);
    }

    private void AddQuestActive(QuestItem quest)
    {
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            Debug.Log("Квест добавлен: " + quest.questNameText.text);
            completeQuestButton.SetActive(true);
            acceptQuestButton.SetActive(false);
        }
        else
        {
            Debug.Log("Квест уже активен: " + quest.questNameText.text);
        }
    }

    private void CompleteQuest(QuestItem quest)
    {
        if (activeQuests.Remove(quest)) // Удаляем квест из активных
        {
            quest.CompleteQuest(); // Завершаем квест
            Debug.Log("Квест завершен: " + quest.questNameText.text);
            completeQuestButton.SetActive(false);
            questUI.SetActive(false);
            questSelectPrefab.SetActive(false);
        }
        else
        {
            Debug.Log("Квест не найден в активных: " + quest.questNameText.text);
        }
    }

    private QuestItem FindQuestByName(string questName)
    {
        foreach (Transform child in questParent.transform)
        {
            QuestItem questItem = child.GetComponent<QuestItem>();
            if (questItem != null && questItem.questNameText.text == questName)
            {
                return questItem; // Возвращаем найденный квест
            }
        }
        return null; // Если квест не найден
    }

    public void ReturnQuestButton()
    {
        questSelect.SetActive(true);
        questInfo.SetActive(false);
    }
    public void EndTalkButton()
    {
        questUI.SetActive(false);
        HideTalkPrompt();
    }

    public void CompleteQuestButton()
    {
        if (activeQuests.Count > 0)
        {
            CompleteQuest(activeQuests[activeQuests.Count - 1]); // Завершить последний активный квест
        }
    }
}