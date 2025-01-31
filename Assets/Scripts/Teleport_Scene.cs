using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        
        yield return new WaitForSecondsRealtime(1f);

        Slider slider = GameObject.Find("LoadingBar").GetComponent<Slider>();
        slider.value = 0f;
        var activeScene = SceneManager.GetActiveScene();
        var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!ao.isDone)
        {
            slider.value = ao.progress;
            Debug.Log("Загрузка: " + ao.progress);
            yield return null;
        }

        var scene = SceneManager.GetSceneByName(sceneName);
        yield return new WaitUntil(() => scene.isLoaded);
        SceneManager.SetActiveScene(scene);

        TeleportPlayer(player);

        Debug.Log("Новая сцена загружена и игрок телепортирован.");
        SceneManager.UnloadSceneAsync("Game_Loading");
        yield return SceneManager.UnloadSceneAsync(activeScene.name);
    }

    private void TeleportPlayer(Transform player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = teleportPoint;
        player.GetComponent<CharacterController>().enabled = true;
    }
}