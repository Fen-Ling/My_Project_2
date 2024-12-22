using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public GameObject CharacterUI;
    public MainMenuState MainMenu;

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
