using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject talkPrompt;
    public GameObject questUI;
    public GameObject questSelect;
    public GameObject questInfo;
    public TMP_Text questDescriptionText;
    public Button acceptQuestButton;
    public Button completeQuestButton;
    public Button returnQuestButton;
    public Button endConversationButton;

    public GameObject questParent;
    public GameObject questPrefab;
    public List<QuestItem> activeQuests = new List<QuestItem>();

    private void Start()
    {
        talkPrompt.SetActive(false);
        questUI.SetActive(false);

        acceptQuestButton.onClick.AddListener(AcceptQuest);
        completeQuestButton.onClick.AddListener(OnCompleteQuestButtonPressed);
        returnQuestButton.onClick.AddListener(ReturnQuestButtonPressed);
        endConversationButton.onClick.AddListener(EndConversation);

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
        acceptQuestButton.gameObject.SetActive(false);
        completeQuestButton.gameObject.SetActive(false);
        returnQuestButton.gameObject.SetActive(false);
        endConversationButton.gameObject.SetActive(true);
    }

    public void QuestSelect()
    {
        questSelect.SetActive(false);
        questInfo.SetActive(true);
        acceptQuestButton.gameObject.SetActive(true);
        returnQuestButton.gameObject.SetActive(true);
        endConversationButton.gameObject.SetActive(false);
    }

    private void AcceptQuest()
    {
        string questName = questDescriptionText.text;

        if (IsQuestObjectExists(questName))
        {
            Debug.Log("Квест с таким именем уже существует!");
            return; // Прерываем выполнение, если объект с таким именем уже существует
        }

        Debug.Log("Квест принят!");
        GameObject questObject = Instantiate(questPrefab, questParent.transform);
        QuestItem questItem = questObject.GetComponent<QuestItem>();

        if (questItem != null)
        {
            questItem.SetQuestName(questName); // Устанавливаем название квеста
            AddQuest(questItem); // Добавляем квест в активные
        }

        questUI.SetActive(false);
    }

    public void AddQuest(QuestItem quest)
    {
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            Debug.Log("Квест добавлен: " + quest.questNameText.text);
            completeQuestButton.gameObject.SetActive(true);
            acceptQuestButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Квест уже активен: " + quest.questNameText.text);
        }
    }

    public void CompleteQuest(QuestItem quest)
    {
        if (activeQuests.Remove(quest)) // Удаляем квест из активных
        {
            quest.CompleteQuest(); // Предполагается, что у QuestItem есть метод для завершения квеста
            Debug.Log("Квест завершен: " + quest.questNameText.text);
            completeQuestButton.gameObject.SetActive(false);
            // Здесь можно также удалить квест из UI, если это необходимо
        }
        else
        {
            Debug.Log("Квест не найден в активных: " + quest.questNameText.text);
        }
    }

    private bool IsQuestObjectExists(string questName)
    {
        foreach (Transform child in questParent.transform)
        {
            QuestItem questItem = child.GetComponent<QuestItem>();
            if (questItem != null && questItem.questNameText.text == questName)
            {
                return true; // Объект с таким именем уже существует
            }
        }
        return false; // Объект не найден
    }

    private void EndConversation()
    {
        questUI.SetActive(false);
        HideTalkPrompt();
    }

    private void ReturnQuestButtonPressed()
    {
        questSelect.SetActive(true);
        questInfo.SetActive(false);
        acceptQuestButton.gameObject.SetActive(false);
        completeQuestButton.gameObject.SetActive(false);
        returnQuestButton.gameObject.SetActive(false);
        endConversationButton.gameObject.SetActive(true);
    }

    private void OnCompleteQuestButtonPressed()
    {
        if (activeQuests.Count > 0)
        {
            CompleteQuest(activeQuests[activeQuests.Count - 1]); // Завершить последний активный квест
        }
    }


    private void UpdateCompleteQuestButtonState(bool state)
    {
        completeQuestButton.gameObject.SetActive(state);
    }
}