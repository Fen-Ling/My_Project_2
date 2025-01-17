using UnityEngine;

public class Player_UI : MonoBehaviour
{
    public GameObject PlayerUI;
    public Game_UI GameUIState;

    private void OnEnable()
    {
        PlayerUI.SetActive(true);
        GameUIState.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        PlayerUI.SetActive(false);
    }
    public void Back_Game()
    {
        gameObject.SetActive(false);
        GameUIState.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
