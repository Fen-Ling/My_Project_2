using TMPro;
using UnityEngine;

public class QuestPrefab : MonoBehaviour
{
    public int idQuest;
    public TMP_Text textName;
    public bool complete;

    public void Start()
    {
        if (idQuest != 0)
        {
            QuestData quest = QuestDataManager.FindQuestByID(idQuest);
            complete = quest.QuestComplete;
            Completed();
            textName.text = quest.QuestName;
            textName = GetComponentInChildren<TMP_Text>();
        }
        else
            gameObject.SetActive(false);
    }

    private void Update()
    {
        Completed();
    }

    private void Completed()
    {
        if (complete == true)
            gameObject.SetActive(false);
    }
}