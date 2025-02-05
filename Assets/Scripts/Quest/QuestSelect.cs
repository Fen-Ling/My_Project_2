using TMPro;
using UnityEngine;

public class QuestSelect : MonoBehaviour
{
    public int idQuest;
    public TMP_Text textName;

    public void Start()
    {
        QuestData quest = QuestDataManager.FindQuestByID(idQuest);
        textName = GetComponentInChildren<TMP_Text>();
        textName.text = quest.QuestName;
    }

}