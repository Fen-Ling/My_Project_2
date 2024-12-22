using UnityEngine;

public class LoadingsState : MonoBehaviour
{
    public GameObject LoadingUI;
    public MainMenuState MainMenu;

    private void OnEnable()
    {
        LoadingUI.SetActive(true);
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

    
}
