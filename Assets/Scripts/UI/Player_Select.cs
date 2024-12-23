using UnityEngine;
using UnityEngine.SceneManagement;

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
        genderIndex = PlayerPrefs.GetInt("SelectGender", 0);
        classIndex = PlayerPrefs.GetInt("SelectClass", 0);

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
        PlayerPrefs.SetInt("SelectGender", genderIndex);
        UpdateCharacterArray();
        ActivateCurrentCharacter();
    }

    public void SelectGenderRight()
    {
        genderIndex = (genderIndex - 1 + 2) % 2;
        PlayerPrefs.SetInt("SelectGender", genderIndex);
        UpdateCharacterArray();
        ActivateCurrentCharacter();
    }

    public void SelectClassLeft()
    {
        classIndex = (classIndex + 1) % 3;
        PlayerPrefs.SetInt("SelectClass", classIndex);
        ActivateCurrentCharacter();
    }

    public void SelectClassRight()
    {
        classIndex = (classIndex - 1 + 3) % 3;
        PlayerPrefs.SetInt("SelectClass", classIndex);
        ActivateCurrentCharacter();
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt("SelectGender", genderIndex);
        PlayerPrefs.SetInt("SelectClass", classIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game_Terra");
    }
}