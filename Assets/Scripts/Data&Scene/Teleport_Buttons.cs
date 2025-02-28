using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport_Buttons : MonoBehaviour
{
    public Button[] buttons;
    public Transform[] points;
    public GameObject button;
    private bool buttonEnabled = false;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => TeleportPlayer(index));
        }
    }

    public void TeleportPlayer(int i)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (i < 0 || i >= points.Length)
            {
                Debug.LogError("Индекс телепорта вне границ");
                return;
            }

            Transform player = GameObject.FindWithTag("Player").transform;

            CharacterController characterController = player.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
                player.position = points[i].position;
                characterController.enabled = true;
            }
            else
            {
                Debug.LogError("Компонент CharacterController не найден у игрока");
            }
        }
        else
        {
            Debug.LogError("Не правильная сцена");
        }
    }

    public void ToggleButtons()
    {
        buttonEnabled = !buttonEnabled;
        button.SetActive(buttonEnabled);
    }
}