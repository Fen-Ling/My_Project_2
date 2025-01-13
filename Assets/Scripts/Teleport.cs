using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }

    public void TeleportPlayer(Transform player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = teleportPoint.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}