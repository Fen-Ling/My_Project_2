using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    public Transform states;
    private void Start()
    {
        foreach (Transform child in states)
        {
            child.gameObject.SetActive(false);
        }
    }
}