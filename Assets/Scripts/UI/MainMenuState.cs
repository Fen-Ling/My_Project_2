using UnityEngine;

public class MainMenuState : MonoBehaviour
{
    public GameObject mainMenuUI;
    public CharacterState CharacterState;
    public LoadingsState LoadingState;
    public SettingsState SettingState;

    private void OnEnable()
    {
        mainMenuUI.SetActive(true);
    }

    private void OnDisable()
    {
        mainMenuUI.SetActive(false);
    }

    public void Play()
    {
        gameObject.SetActive(false);
        CharacterState.gameObject.SetActive(true);
    }
    public void Load()
    {
        gameObject.SetActive(false);
        LoadingState.gameObject.SetActive(true);
    }
    public void Settings()
    {
        gameObject.SetActive(false);
        SettingState.gameObject.SetActive(true);
    }


}
