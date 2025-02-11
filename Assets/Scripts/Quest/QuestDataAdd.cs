using TMPro;
using UnityEngine;

public class QuestDataAdd : MonoBehaviour
{
    public TMP_InputField idField;
    public TMP_InputField namequestField;
    public TMP_InputField textquestField;
    public TMP_InputField progressnullField;
    public TMP_InputField progresscompleteField;
    private int id;
    private string namequest;
    private string textquest;
    private int progressnull;
    private int progresscomplete;

    public void AddQuest()
    {
        int.TryParse(idField.text, out id);
        int.TryParse(progressnullField.text, out progressnull);
        int.TryParse(progresscompleteField.text, out progresscomplete);
        namequest = namequestField.text;
        textquest = textquestField.text;

        QuestDataManager.AddQuestData(id, namequest, textquest, progressnull, progresscomplete, false);
        ClearFields();
    }

    private void ClearFields()
    {
        idField.text = string.Empty;
        namequestField.text = string.Empty;
        textquestField.text = string.Empty;
        progressnullField.text = string.Empty;
        progresscompleteField.text = string.Empty;
    }
}
