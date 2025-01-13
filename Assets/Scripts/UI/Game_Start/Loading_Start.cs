using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class Loadings_Start : MonoBehaviour
{
    public GameObject LoadingUI;
    public Main_Menu MainMenu;
    public Button[] buttons;
    public string defaultFilename;

    private void OnEnable()
    {
        LoadingUI.SetActive(true);
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
        LoadingUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    public void Load(string filename)
    {
        if (PlayerDataManager.LoadPlayerData(filename))
        {
            int indexScene = PlayerDataManager.playerData.sceneIndex;

            if (indexScene == 1)
            {
                SceneManager.LoadScene(indexScene);
            }
            else
            {
                PlayerDataManager.playerData.position = new Vector3(433, 69, 564);
                SceneManager.LoadScene(1);
            }

        }
    }
}
