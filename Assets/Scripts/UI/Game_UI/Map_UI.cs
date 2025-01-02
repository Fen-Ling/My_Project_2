using UnityEngine;

public class Map_UI : MonoBehaviour
{
    public GameObject MapUI;
    public Game_UI GameState;

    private void OnEnable()
    {
        MapUI.SetActive(true);
        GameState.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        MapUI.SetActive(false);
    }
    public void Back_Game()
    {
        gameObject.SetActive(false);
        GameState.gameObject.SetActive(true);        
        Time.timeScale = 1;

    }

}
