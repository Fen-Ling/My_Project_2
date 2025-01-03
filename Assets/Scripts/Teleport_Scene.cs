using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
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
        SceneManager.LoadScene("Game_Loading", LoadSceneMode.Additive);
        Time.timeScale = 0;

        var activeScene = SceneManager.GetActiveScene();

        var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!ao.isDone)
        {
            Debug.Log("Загрузка: " + ao.progress);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(2f);

        var scene = SceneManager.GetSceneByName(sceneName);

        yield return new WaitUntil(() => scene.isLoaded);

        SceneManager.SetActiveScene(scene);

        TeleportPlayer(player);

        Debug.Log("Новая сцена загружена и игрок телепортирован.");
        SceneManager.UnloadSceneAsync("Game_Loading");
        Time.timeScale = 1;
        yield return SceneManager.UnloadSceneAsync(activeScene.name);
    }

    private void TeleportPlayer(Transform player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = teleportPoint;
        player.GetComponent<CharacterController>().enabled = true;
    }
}