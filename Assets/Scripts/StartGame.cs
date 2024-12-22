using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Transform states;

    private void Start()
    {
        foreach (Transform child in states)
        {
            child.gameObject.SetActive(false);
        }
        states.GetChild(0).gameObject.SetActive(true);
    }

}

