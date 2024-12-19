using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadSceneAsync(sceneToLoad, other.transform));
        }
    }

    IEnumerator LoadSceneAsync(string sceneName, Transform player)
    {
        // SceneManager.LoadScene("Empty", LoadSceneMode.Additive);
        // var emptyScene = SceneManager.GetSceneByName("Empty");
        var activeScene = SceneManager.GetActiveScene();
        var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!ao.isDone)
        {
            Debug.Log("Загрузка: " + ao.progress);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        
        TeleportPlayer(player);

        yield return SceneManager.UnloadSceneAsync(activeScene.name);
        Debug.Log("Новая сцена загружена и игрок телепортирован.");

        // SceneManager.UnloadSceneAsync(emptyScene.name);
    }

    private void TeleportPlayer(Transform player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = teleportPoint;
        player.GetComponent<CharacterController>().enabled = true;
    }
}