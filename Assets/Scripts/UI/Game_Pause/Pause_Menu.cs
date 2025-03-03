using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Game_UI GameUIState;
    public Saving_Game SaveGame;
    public Settings_Game SettingGame;
    public GameObject persistentObjects;

    private void OnEnable()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Back_Game()
    {
        gameObject.SetActive(false);
        GameUIState.gameObject.SetActive(true);
        Time.timeScale = 1;

    }

    public void Save()
    {
        gameObject.SetActive(false);
        SaveGame.gameObject.SetActive(true);
    }

    public void Back_to_Menu()
    {
        QuestDataManager.ResetQuestData();
        StartCoroutine(LoadSceneAsync("Game_StartMenu"));
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        SettingGame.gameObject.SetActive(true);
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.LoadScene("Game_Loading", LoadSceneMode.Additive);

        yield return new WaitForSecondsRealtime(1f);

        Slider slider = GameObject.Find("LoadingBar").GetComponent<Slider>();
        slider.value = 0f;
        var activeScene = SceneManager.GetActiveScene();
        var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!ao.isDone)
        {
            slider.value = ao.progress;
            Debug.Log("Загрузка: " + ao.progress);
            yield return null;
        }

        var scene = SceneManager.GetSceneByName(sceneName);
        yield return new WaitUntil(() => scene.isLoaded);
        SceneManager.SetActiveScene(scene);
        Destroy(player);
        Destroy(persistentObjects);
        Debug.Log("Новая сцена загружена");
        SceneManager.UnloadSceneAsync("Game_Loading");
        yield return SceneManager.UnloadSceneAsync(activeScene.name);
    }

}