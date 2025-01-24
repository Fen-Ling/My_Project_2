using Unity.Entities;
using UnityEngine;

public class MaxMap : MonoBehaviour
{
    public GameObject MaxMapCamera;

    void OnEnable()
    {
        MaxMapCamera.SetActive(true);
    }

    void OnDisable()
    {
        MaxMapCamera.SetActive(false);
    }
}
