using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPrefab : MonoBehaviour
{
    public int idQuest;
    public TMP_Text textName;
    public bool complete;
    private Button questButton;
    private QuestManager questManager;

    public void Start()
    {
        if (idQuest != 0)
        {
            QuestData quest = QuestDataManager.FindQuestByID(idQuest);
            complete = quest.QuestComplete;
            Completed();
            textName.text = quest.QuestName;
            textName = GetComponentInChildren<TMP_Text>();
            questManager = FindObjectOfType<QuestManager>();
            questButton = GetComponent<Button>();
            questButton.onClick.AddListener(() => questManager.QuestSelect(idQuest));
        }
        else
            gameObject.SetActive(false);
    }

    private void Completed()
    {
        if (complete == true)
            gameObject.SetActive(false);
    }
}