using UnityEngine;

public class Loadings_State : MonoBehaviour
{
    public GameObject LoadingUI;
    public Pause_Menu PauseMenu;

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
        PauseMenu.gameObject.SetActive(true);
    }

    
}
