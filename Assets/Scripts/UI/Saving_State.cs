using UnityEngine;

public class Saving_State : MonoBehaviour
{
    public GameObject SaveUI;
    public Pause_Menu PauseMenu;

    private void OnEnable()
    {
        SaveUI.SetActive(true);
    }

    private void OnDisable()
    {
        SaveUI.SetActive(false);
    }

    public void BackToPauseMenu()
    {
        gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }

    
}
