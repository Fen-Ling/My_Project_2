using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera targetCamera;

    void Start()
    {
        targetCamera = GameObject.Find("Cam1").GetComponent<Camera>();
    }

    void Update()
    {
        if (targetCamera != null)
        {
            transform.LookAt(targetCamera.transform);
        }
    }
}