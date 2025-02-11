using System.Collections;
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
                StartCoroutine(LoadSceneAsync(indexScene));
            }
            else
            {
                PlayerDataManager.playerData.position = new Vector3(433, 69, 564);
                StartCoroutine(LoadSceneAsync(1));
            }
        }
    }

    IEnumerator LoadSceneAsync(int sceneName)
    {
        SceneManager.LoadScene("Game_Loading", LoadSceneMode.Additive);
        yield return new WaitForSecondsRealtime(1f);

        var activeScene = SceneManager.GetActiveScene();
        var ao = SceneManager.LoadSceneAsync(sceneName);
        Slider slider = GameObject.Find("LoadingBar").GetComponent<Slider>();
        slider.value = 0f;
        while (!ao.isDone)
        {
            slider.value = ao.progress;
            Debug.Log("Загрузка: " + ao.progress);
            yield return null;
        }

        var scene = SceneManager.GetSceneByBuildIndex(sceneName);
        yield return new WaitUntil(() => scene.isLoaded);

        SceneManager.SetActiveScene(scene);
        Debug.Log("Новая сцена загружена");
        SceneManager.UnloadSceneAsync("Game_Loading");
        yield return SceneManager.UnloadSceneAsync(activeScene.name);
    }
}
