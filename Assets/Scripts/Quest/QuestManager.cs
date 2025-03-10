using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject talkPrompt;
    public GameObject questItemPrompt;
    public GameObject questUI;
    public GameObject questSelectUI;
    public GameObject questInfoUI;
    public GameObject acceptQuestButton;
    public GameObject completeQuestButton;
    public GameObject questSelect;
    public GameObject questSelectPref;
    public TMP_Text questNameText;
    public TMP_Text questText;
    public GameObject questParent;
    public GameObject questPrefab;

    public List<QuestItem> activeQuests = new List<QuestItem>();
    private QuestItem currentQuest;

    private void Start()
    {
        QuestDataManager.LoadQuestData();
        talkPrompt.SetActive(false);
        questUI.SetActive(false);
        acceptQuestButton.SetActive(false);
        completeQuestButton.SetActive(false);
        LoadActiveQuests();
    }

    public void ShowTalkPrompt()
    {
        talkPrompt.SetActive(true);
    }

    public void HideTalkPrompt()
    {
        talkPrompt.SetActive(false);
    }

    public void ShowQuestItem()
    {
        questItemPrompt.SetActive(true);
    }

    public void HideQuestItem()
    {
        questItemPrompt.SetActive(false);
    }

    public void ShowQuestUI()
    {
        questUI.SetActive(true);
        questSelectUI.SetActive(true);
        questInfoUI.SetActive(false);
    }

    public void QuestSelection(int[] questIDs)
    {
        ClearQuestList();

        foreach (int questID in questIDs)
        {
            QuestData questpr = QuestDataManager.FindQuestByID(questID);
            if (questpr != null)
            {
                GameObject questPrefabItem = Instantiate(questSelectPref, questSelect.transform);
                QuestPrefab questPrefabScript = questPrefabItem.GetComponent<QuestPrefab>();
                questPrefabScript.idQuest = questpr.QuestID;
            }
        }
    }

    private void ClearQuestList()
    {
        foreach (Transform child in questSelect.transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void QuestSelect(int index)
    {
        questSelectUI.SetActive(false);
        questInfoUI.SetActive(true);

        QuestData quest = QuestDataManager.FindQuestByID(index);
        if (quest != null)
        {
            questNameText.text = quest.QuestName;
            questText.text = quest.QuestInfo;

            string questName = questNameText.text;
            QuestItem selectedQuest = FindQuestByName(questName);

            if (selectedQuest != null)
            {
                currentQuest = selectedQuest;
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
    }

    public void AcceptQuestButton()
    {
        string questName = questNameText.text;

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
            questItem.SetQuestName(questName);

            AddQuestActive(questItem);
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
        if (activeQuests.Remove(quest))
        {
            quest.CompleteQuest();
            questUI.SetActive(false);
        }
        else
        {
            Debug.Log("Квест не найден в активных: " + quest.questNameText.text);
        }
    }

    public List<string> GetActiveQuestNames()
    {
        List<string> questNames = new List<string>();
        foreach (var quest in activeQuests)
        {
            questNames.Add(quest.questNameText.text);
        }
        return questNames;
    }

    public void LoadActiveQuests()
    {
        List<string> questNames = PlayerDataManager.playerData.activeQuests;
        foreach (var questName in questNames)
        {
            QuestData questData = QuestDataManager.FindQuestByName(questName);
            if (questData != null)
            {
                if (FindQuestByName(questName))
                {
                    Debug.Log("Квест с таким именем уже существует!");
                    return;
                }
                GameObject questObject = Instantiate(questPrefab, questParent.transform);
                QuestItem questItem = questObject.GetComponent<QuestItem>();
                if (questItem != null)
                {
                    questItem.SetQuestName(questData.QuestName);
                    AddQuestActive(questItem);
                }
            }
        }
    }

    private QuestItem FindQuestByName(string questName)
    {
        foreach (Transform child in questParent.transform)
        {
            QuestItem questItem = child.GetComponent<QuestItem>();
            if (questItem != null && questItem.questNameText.text == questName)
            {
                return questItem;
            }
        }
        return null;
    }

    public void CompleteQuestButton()
    {
        if (currentQuest != null)
        {
            CompleteQuest(currentQuest);
        }
        else
        {
            Debug.Log("Нет выбранного квеста для завершения.");
        }
    }

    public void ReturnQuestButton()
    {
        questSelectUI.SetActive(true);
        questInfoUI.SetActive(false);
    }

    public void EndTalkButton()
    {
        questUI.SetActive(false);
        HideTalkPrompt();
    }

}