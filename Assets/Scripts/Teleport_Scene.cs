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
            StartCoroutine(TeleportPlayer(other.transform));
        }
    }

    private IEnumerator TeleportPlayer(Transform player)
    {
        // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }



        player.GetComponent<CharacterController>().enabled = false;
        player.position = teleportPoint;
        player.GetComponent<CharacterController>().enabled = true;

    }
}