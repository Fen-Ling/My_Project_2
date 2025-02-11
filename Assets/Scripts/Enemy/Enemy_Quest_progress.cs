using UnityEngine;

public class Enemy_Quest_progress : MonoBehaviour
{
    private int progress = 1;
    public int[] questID;
    private int IDquest;
    public GameObject activequest;
    private GameObject[] questactive;

    private void Start()
    {
        activequest = GameObject.FindGameObjectWithTag("QuestActive");
    }
    private void Update()
    {
                if (activequest != null)
        {
            int childCount = activequest.transform.childCount;
            questactive = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                questactive[i] = activequest.transform.GetChild(i).gameObject;
            }
        }
    }
    public void QuestProgress()
    {
        for (int i = 0; i < questID.Length; i++)
        {
            IDquest = questID[i];
            var quest = questactive[i].GetComponent<QuestItem>();
            var questact = QuestDataManager.FindQuestByName(quest.questNameText.text);
            if (IDquest == questact.QuestID)
            {
                quest.ProgressQuest(progress);
            }
        }
    }
}
