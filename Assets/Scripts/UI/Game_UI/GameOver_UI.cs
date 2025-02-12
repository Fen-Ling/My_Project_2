using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_UI : MonoBehaviour
{
    public GameObject GameOverUI;
    public Game_UI GameState;
    public GameObject persistentObjects;
    public AudioClip audioGameOver;
    private AudioSource hitAudioSource;

    private void OnEnable()
    {
        GameOverUI.SetActive(true);
        GameState.gameObject.SetActive(false);
        hitAudioSource.Play();
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        GameOverUI.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Destroy(persistentObjects);
        SceneManager.LoadScene(0);
    }

}
