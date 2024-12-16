using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public string sceneToLoad; // Название сцены для загрузки
    public Vector3 spawnPosition; // Позиция, куда будет телепортирован игрок

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверка, что объект - игрок
        {
            StartCoroutine(TeleportPlayer(other.transform));
        }
    }

    private IEnumerator TeleportPlayer(Transform player)
    {
        // Загрузить новую сцену
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        
        // Ожидание завершения загрузки
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Телепортация игрока на нужную позицию
        player.position = spawnPosition;
    }
}