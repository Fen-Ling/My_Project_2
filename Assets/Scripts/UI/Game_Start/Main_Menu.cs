using UnityEngine;

public class Main_Menu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public Character_Start CharacterState;
    public Loadings_Start LoadingState;
    public Settings_Start SettingState;

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
