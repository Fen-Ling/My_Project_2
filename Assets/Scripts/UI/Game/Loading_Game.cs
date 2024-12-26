using UnityEngine;

public class Loadings_Game : MonoBehaviour
{
    public GameObject LoadingUI;
    public Pause_Menu PauseMenu;

    private void OnEnable()
    {
        LoadingUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        LoadingUI.SetActive(false);
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }

    
}
