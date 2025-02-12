using System;
using System.IO;
using TMPro;
using Unity.Core;
using UnityEngine;
using UnityEngine.UI;
public class Saving_Game : MonoBehaviour
{
    public GameObject SaveUI;
    public Pause_Menu PauseMenu;
    public Button[] buttons;
    public string defaultFilename;
    private GameObject player;

    private void OnEnable()
    {
        SaveUI.SetActive(true);
        Time.timeScale = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        
        for (int i = 0; i < buttons.Length; i++)
        {
            string filename = defaultFilename + (i + 1).ToString();
            string filepath = Path.Combine(Application.persistentDataPath, filename + ".json");

            if (File.Exists(filepath))
            {
                buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = filename;
            }
            else
            {
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "-";
            }
        }

    }

    private void OnDisable()
    {
        SaveUI.SetActive(false);
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }

    public void Saving(int index)
    {
        string filename = defaultFilename + (index + 1).ToString();
        QuestDataManager.SaveQuestDataPlayer(filename + "quest.json");
        PlayerDataManager.SavePlayerData(filename + ".json", player);

        buttons[index].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = filename;
    }
    public void Delete(int index)
    {
        string filename = defaultFilename + (index + 1).ToString();
        QuestDataManager.DeleteQuestDataPlayer(filename + "quest.json");
        PlayerDataManager.DeletePlayerData(filename + ".json");
        buttons[index].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "-";
    }
}
