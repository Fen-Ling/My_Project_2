using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestNPSTalk : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction m_questAction;
    public GameObject questManager;
    public int[] questID;
    private GameObject activquest;
    public List<GameObject> questctive = new List<GameObject>();

    private bool isPlayerInRange = false;

    private void Awake()
    {
        questManager = GameObject.FindGameObjectWithTag("QuestManager");
        activquest = GameObject.FindGameObjectWithTag("QuestActive");
        UpdateActiveQuestArray();
        m_questAction = inputActions.FindAction("UI/NPSTalk");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateActiveQuestArray();
            isPlayerInRange = true;
            Debug.Log("Collider +");
            questManager.GetComponent<QuestManager>().ShowTalkPrompt();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateActiveQuestArray();
            isPlayerInRange = false;
            Debug.Log("Collider -");
            questManager.GetComponent<QuestManager>().HideTalkPrompt();
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInRange && m_questAction.IsPressed())
        {
                QuestTalk();
        }
    }

    public void UpdateActiveQuestArray()
    {
        questctive.Clear();
        int childCount = activquest.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            questctive.Add(activquest.transform.GetChild(i).gameObject);
        }
    }

    private void QuestTalk()
    {
        foreach (var questObj in questctive)
        {
            if (questObj.TryGetComponent(out QuestItem quest))
            {
                var questact = QuestDataManager.FindQuestByName(quest.questNameText.text);
                if (questact == null) continue;
                int activeQuestID = questact.QuestID;
                if (Array.Exists(questID, id => id == activeQuestID))
                {
                    quest.ProgressQuest(1);
                    Debug.Log(quest.questNameText.text + "+ 1");
                }
            }
        }
    }
}