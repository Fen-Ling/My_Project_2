using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public string playerTag = "Player"; // Тег игрока
    private CinemachineCamera virtualCamera;

    private void Start()
    {
        // Получаем компонент CinemachineVirtualCamera
        virtualCamera = GetComponent<CinemachineCamera>();

        // Находим игрока по тегу
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            // Присваиваем игрока в качестве Tracking Target
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
        else
        {
            Debug.LogWarning("Игрок с тегом '" + playerTag + "' не найден!");
        }
    }
}