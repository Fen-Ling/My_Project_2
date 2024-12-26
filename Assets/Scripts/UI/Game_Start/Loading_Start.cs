using UnityEngine;

public class Loadings_Start : MonoBehaviour
{
    public GameObject LoadingUI;
    public Main_Menu MainMenu;

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
