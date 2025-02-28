using UnityEngine;

public class Lock_At_Player : MonoBehaviour
{
    private Camera targetCamera;

    void Awake()
    {
        targetCamera = GameObject.Find("Cam1").GetComponent<Camera>();
    }

    void Update()
    {
        if (targetCamera != null)
        {
            transform.LookAt(targetCamera.transform);
        }
        else
        {
            targetCamera = GameObject.Find("Cam1").GetComponent<Camera>();
        }
    }
}