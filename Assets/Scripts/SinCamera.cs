using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public string playerTag = "Player";
    private CinemachineCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineCamera>();

        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
        else
        {
            Debug.LogWarning("Игрок с тегом '" + playerTag + "' не найден!");
        }
    }
}