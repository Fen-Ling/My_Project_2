using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Quest_progress : MonoBehaviour
{
    private int progress = 1;
    public int[] questID;
    private GameObject activequest;
    public List<GameObject> questactive = new List<GameObject>();

    private void Start()
    {
        activequest = GameObject.FindGameObjectWithTag("QuestActive");
        UpdateActiveQuestArray();
    }
    private void Update()
    {
        if (activequest != null)
        {
            UpdateActiveQuestArray();
        }
    }

    public void UpdateActiveQuestArray()
    {
        questactive.Clear();
        int childCount = activequest.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            questactive.Add(activequest.transform.GetChild(i).gameObject);
        }
    }
    public void QuestProgress()
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
                    quest.ProgressQuest(progress);
                    if (questact.QuestProgressStart < questact.QuestProgressEnd)
                    {
                        questact.QuestProgressStart = questact.QuestProgressStart + 1;
                    }
                    Debug.Log(quest.questNameText.text + "+ 1");
                }
            }
        }
    }

}