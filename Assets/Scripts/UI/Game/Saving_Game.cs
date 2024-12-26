using System;
using UnityEngine;
public class Saving_Game : MonoBehaviour
{
    public GameObject SaveUI;
    public Pause_Menu PauseMenu;

    private void OnEnable()
    {
        SaveUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        SaveUI.SetActive(false);
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(true);
    }

    public void Saving()
    {


    }

}
