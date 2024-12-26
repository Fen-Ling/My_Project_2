using UnityEngine;

public class Character_Start : MonoBehaviour
{
    public GameObject CharacterUI;
    public Main_Menu MainMenu;

    private void OnEnable()
    {
        CharacterUI.SetActive(true);
    }

    private void OnDisable()
    {
        CharacterUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
}
