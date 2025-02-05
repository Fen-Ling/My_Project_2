using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public int QuestID;
    public string QuestName;
    public string QuestInfo;
    public bool QuestComplete;
}

[System.Serializable]
public class QuestDataList
{
    public List<QuestData> quests = new List<QuestData>();
}