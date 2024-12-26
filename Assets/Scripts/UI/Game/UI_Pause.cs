using UnityEngine;
using UnityEngine.InputSystem;

public class GameControls : MonoBehaviour
{
    public Transform states;
    public InputActionAsset inputActions;
    private InputAction pauseAction;


    private void Start()
    {
        pauseAction = inputActions.FindAction("UI/Pause");
        pauseAction.performed += TogglePauseMenu;

        foreach (Transform child in states)
        {
            child.gameObject.SetActive(false);
        }

    }
    private void TogglePauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Логика для открытия/закрытия меню паузы
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0; // Остановить игру
                states.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1; // Продолжить игру
                states.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}