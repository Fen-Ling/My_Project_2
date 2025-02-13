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
        if (activequest != null && questactive == null)
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
                int IDquest = GetQuestID(quest);
                var questact = QuestDataManager.FindQuestByName(quest.questNameText.text);

                if (IDquest == questact.QuestID)
                {
                    quest.ProgressQuest(progress);
                    Debug.Log(quest.questNameText.text + "+1");
                }
            }
        }
    }

    private int GetQuestID(QuestItem quest)
    {
        return questID[Array.IndexOf(questactive.ToArray(), quest.gameObject)];
    }
}