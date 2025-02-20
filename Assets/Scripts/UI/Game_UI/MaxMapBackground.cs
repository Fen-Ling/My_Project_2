using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxMapBackground : MonoBehaviour
{
    public GameObject backgroundTerra;
    public GameObject backgroundDung;
    private int sceneIndex;

    private void Start()
    {
        backgroundTerra.SetActive(false);
        backgroundDung.SetActive(false);
    }
    private void OnEnable()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        if (sceneIndex == 1)
        {
            backgroundTerra.SetActive(true);
            backgroundDung.SetActive(false);
        }
        else
        {
            if (sceneIndex == 2)
            {
                backgroundTerra.SetActive(false);
                backgroundDung.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        backgroundTerra.SetActive(false);
        backgroundDung.SetActive(false);
    }

}
