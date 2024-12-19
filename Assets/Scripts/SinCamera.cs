using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class CinemachineCameraSetup : MonoBehaviour
{
    private void Start()
    {
        // Подписываемся на событие загрузки новой сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Отписываемся от события, когда объект уничтожается
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ищем игрока по тегу "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Находим компонент CinemachineVirtualCamera
            CinemachineCamera virtualCamera = GetComponent<CinemachineCamera>();
            if (virtualCamera != null)
            {
                // Устанавливаем цель для камеры
                virtualCamera.Follow = player.transform;
                virtualCamera.LookAt = player.transform;
            }
        }
        else
        {
            Debug.LogWarning("Player с тегом 'Player' не найден!");
        }
    }
}