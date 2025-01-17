using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_Select : MonoBehaviour
{
    public GameObject[] maleCharacters;
    public GameObject[] femaleCharacters;
    public GameObject[] warriorCharacters;
    public GameObject[] mageCharacters;
    public GameObject[] archerCharacters;

    private int genderIndex; // 0 - мужской, 1 - женский
    private int classIndex; // 0 - воин, 1 - маг, 2 - лучник
    private GameObject[] currentCharacters;

    private void Start()
    {
        genderIndex = 0;
        classIndex = 0;

        UpdateCharacterArray();
        ActivateCurrentCharacter();
    }

    private void UpdateCharacterArray()
    {
        if (genderIndex == 0)
        {
            currentCharacters = maleCharacters;
        }
        else
        {
            currentCharacters = femaleCharacters;
        }
    }

    private void ActivateCurrentCharacter()
    {
        foreach (GameObject go in maleCharacters)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in femaleCharacters)
        {
            go.SetActive(false);
        }

        if (classIndex >= 0 && classIndex < currentCharacters.Length)
        {
            currentCharacters[classIndex].SetActive(true);
        }
    }

    public void SelectGenderLeft()
    {
        genderIndex = (genderIndex + 1) % 2;
        UpdateCharacterArray();
        ActivateCurrentCharacter();
    }

    public void SelectGenderRight()
    {
        genderIndex = (genderIndex - 1 + 2) % 2;
        UpdateCharacterArray();
        ActivateCurrentCharacter();
    }

    public void SelectClassLeft()
    {
        classIndex = (classIndex + 1) % 3;
        ActivateCurrentCharacter();
    }

    public void SelectClassRight()
    {
        classIndex = (classIndex - 1 + 3) % 3;
        ActivateCurrentCharacter();
    }

    public void StartScene()
    {
        PlayerDataManager.NewGame_PlayerData(genderIndex, classIndex);

        StartCoroutine(LoadSceneAsync(1));
    }

    IEnumerator LoadSceneAsync(int sceneName)
    {
        SceneManager.LoadScene("Game_Loading", LoadSceneMode.Additive);

        var activeScene = SceneManager.GetActiveScene();

        var ao = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!ao.isDone)
        {
            Debug.Log("Загрузка: " + ao.progress);
            yield return null;
        }

        var scene = SceneManager.GetSceneByBuildIndex(sceneName);

        yield return new WaitUntil(() => scene.isLoaded);

        SceneManager.SetActiveScene(scene);

        Debug.Log("Новая сцена загружена");
        SceneManager.UnloadSceneAsync("Game_Loading");
        yield return SceneManager.UnloadSceneAsync(activeScene.name);
    }
}