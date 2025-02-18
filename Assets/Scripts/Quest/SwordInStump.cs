using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordInStump : MonoBehaviour
{
    public GameObject Sword;
    public InputActionAsset inputActions;
    private InputAction m_questAction;
    public QuestManager questManager;
    public int[] questID;
    private GameObject activequest;
    public List<GameObject> questactive = new List<GameObject>();

    private bool isPlayerInRange = false;

    void Start()
    {
        m_questAction = inputActions.FindAction("UI/NPSTalk");
        UpdateActiveQuestArray();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateActiveQuestArray();
            isPlayerInRange = true;
            Debug.Log("Collider +");
            questManager.GetComponent<QuestManager>().ShowQuestItem();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateActiveQuestArray();
            isPlayerInRange = false;
            Debug.Log("Collider -");
            questManager.GetComponent<QuestManager>().HideQuestItem();
        }
    }

    private void FixedUpdate()
    {

        if (isPlayerInRange && m_questAction.IsPressed())
        {
            if (Sword != null)
            {
                QuestItemAdd();
            }
        }
    }

    public void UpdateActiveQuestArray()
    {
        activequest = GameObject.FindGameObjectWithTag("QuestActive");
        questactive.Clear();
        int childCount = activequest.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            questactive.Add(activequest.transform.GetChild(i).gameObject);
        }
    }

    private void QuestItemAdd()
    {
        foreach (var questObj in questactive)
        {
            if (questObj.TryGetComponent(out QuestItem quest))
            {
                var questact = QuestDataManager.FindQuestByName(quest.questNameText.text);
                if (questact == null) continue;
                int activeQuestID = questact.QuestID;
                if (Array.Exists(questID, id => id == activeQuestID))
                {
                    quest.ProgressQuest(1);
                    Destroy(Sword);
                    Debug.Log(quest.questNameText.text + "+ 1");
                }
            }
        }
    }
}