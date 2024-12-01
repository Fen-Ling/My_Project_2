using UnityEngine;

public class Lock_At_Player : MonoBehaviour
{
    public Transform camera;
    void LateUpdate()
    {
        transform.LookAt(camera);
    }
}
