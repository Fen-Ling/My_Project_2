using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Loadings_Game LoadGame;
    public Saving_Game SaveGame;
    public Settings_Game SettingGame;

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
        Time.timeScale = 1;

    }

    public void Load()
    {
        gameObject.SetActive(false);
        LoadGame.gameObject.SetActive(true);
    }
    public void Save()
    {
        gameObject.SetActive(false);
        SaveGame.gameObject.SetActive(true);
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        SettingGame.gameObject.SetActive(true);
    }

}