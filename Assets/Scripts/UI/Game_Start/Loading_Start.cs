using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadings_Start : MonoBehaviour
{
    public GameObject LoadingUI;
    public Main_Menu MainMenu;
    private PlayerDataManager PDM;

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

    public void Loading()
    {
        PDM.LoadPlayerData();
        SceneManager.LoadScene("Game_Terra");
    }

    
}
