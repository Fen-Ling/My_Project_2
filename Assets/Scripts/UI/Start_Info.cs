using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Info : MonoBehaviour
{
    public GameObject infoWorld;
    public GameObject infoInput;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 0;
            infoWorld.SetActive(true);
            infoInput.SetActive(false);
        }
    }

    public void Next()
    {
        infoWorld.SetActive(false);
        infoInput.SetActive(true);
    }

    public void StartGame()
    {
        infoWorld.SetActive(false);
        infoInput.SetActive(false);
        Time.timeScale = 1;
    }
}
