using UnityEngine;

public class Game_UI : MonoBehaviour
{
    public GameObject GameUI;
    public Pause_Menu pauseMenuState;
    public Map_UI MapState;
    public Player_UI PlayerState;

    private void OnEnable()
    {
        GameUI.SetActive(true);
    }
    private void OnDisable()
    {
        GameUI.SetActive(false);
    }
    public void PauseMenu()
    {
        gameObject.SetActive(false);
        pauseMenuState.gameObject.SetActive(true);
    }
    public void PlayerInf()
    {
        gameObject.SetActive(false);
        PlayerState.gameObject.SetActive(true);
    }
    public void MaxMap()
    {
        gameObject.SetActive(false);
        MapState.gameObject.SetActive(true);
    }

}
