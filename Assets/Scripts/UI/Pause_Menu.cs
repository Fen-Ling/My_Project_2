using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Loadings_State LoadState;
    public Saving_State SaveState;
    public Settings_State SettingState;


    private void OnEnable()
    {
        pauseMenuUI.SetActive(true);
    }

    private void OnDisable()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Back_Game()
    {
        gameObject.SetActive(false);

    }

    public void Load()
    {
        gameObject.SetActive(false);
        LoadState.gameObject.SetActive(true);
    }
    public void Save()
    {
        gameObject.SetActive(false);
        SaveState.gameObject.SetActive(true);
    }

    public void Settings()
    {
        gameObject.SetActive(false);
        SettingState.gameObject.SetActive(true);
    }

    public void Back_Menu()
    {
        gameObject.SetActive(false);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game_Start");
    }
}