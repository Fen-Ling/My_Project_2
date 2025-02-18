using UnityEngine;
using UnityEngine.SceneManagement;

public class MaxMapCam : MonoBehaviour
{
    public GameObject backgraundTerra;
    public GameObject backgraundDung;
    private int sceneIndex;

    private void Start()
    {
        backgraundTerra.SetActive(false);
        backgraundDung.SetActive(false);
    }
    private void OnEnable()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        if (sceneIndex == 1)
        {
            backgraundTerra.SetActive(true);
            backgraundDung.SetActive(false);
        }
        else
        {
            if (sceneIndex == 2)
            {
                backgraundTerra.SetActive(false);
                backgraundDung.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        backgraundTerra.SetActive(false);
        backgraundDung.SetActive(false);
    }

}
