using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] maleCharacters;
    public GameObject[] femaleCharacters;
    private int genderIndex;
    private int classIndex;
    private GameObject[] currentCharacters;

    private void Start()
    {
        genderIndex = PlayerPrefs.GetInt("SelectGender");
        classIndex = PlayerPrefs.GetInt("SelectClass");

        UpdateCharacterArray();
        ActivateCurrentCharacter();
        RemoveInactiveCharacters(currentCharacters, classIndex);

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
            currentCharacters[classIndex].SetActive(true); // Активируем только первого персонажа
        }
    }

    private void RemoveInactiveCharacters(GameObject[] characters, int activeIndex)
    {
        for (int i = characters.Length - 1; i >= 0; i--)
        {
            if (i != activeIndex)
            {
                Destroy(characters[i]);
            }
        }

        GameObject[] oppositeGenderCharacters = (genderIndex == 0) ? femaleCharacters : maleCharacters;
        for (int i = oppositeGenderCharacters.Length - 1; i >= 0; i--)
        {
            Destroy(oppositeGenderCharacters[i]);
        }
    }

}
