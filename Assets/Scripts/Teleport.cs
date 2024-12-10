using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportPoint; // Точка, куда будет телепортирован игрок

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }

    private void TeleportPlayer(Transform player)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.position = teleportPoint.position;
        player.GetComponent<CharacterController>().enabled = true;
    }
}