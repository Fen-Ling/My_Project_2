using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Select : MonoBehaviour
{
    public GameObject[] maleCharacters; // Массив для мужских персонажей
    public GameObject[] femaleCharacters; // Массив для женских персонажей
    public GameObject[] warriorCharacters; // Массив для воинов
    public GameObject[] mageCharacters; // Массив для магов
    public GameObject[] archerCharacters; // Массив для лучников

    private int genderIndex; // 0 - мужской, 1 - женский
    private int classIndex; // 0 - воин, 1 - маг, 2 - лучник
    private GameObject[] currentCharacters; // Текущий массив персонажей

    private void Start()
    {
        genderIndex = PlayerPrefs.GetInt("SelectGender", 0); // По умолчанию мужской
        classIndex = PlayerPrefs.GetInt("SelectClass", 0); // По умолчанию воин

        UpdateCharacterArray();
        ActivateCurrentCharacter(); // Активируем только текущий (первый) персонаж
    }

    private void UpdateCharacterArray()
    {
        if (genderIndex == 0) // Мужской
        {
            currentCharacters = maleCharacters;
        }
        else // Женский
        {
            currentCharacters = femaleCharacters;
        }
    }

    private void ActivateCurrentCharacter()
    {
        // Сначала деактивируем всех персонажей
        foreach (GameObject go in maleCharacters)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in femaleCharacters)
        {
            go.SetActive(false);
        }

        // Активируем только нулевого персонажа в текущем массиве
        if (classIndex >= 0 && classIndex < currentCharacters.Length)
        {
            currentCharacters[classIndex].SetActive(true); // Активируем только первого персонажа
        }
    }

    public void SelectGenderLeft()
    {
        genderIndex = (genderIndex + 1) % 2; // Переключаем пол
        PlayerPrefs.SetInt("SelectGender", genderIndex);
        UpdateCharacterArray();
        ActivateCurrentCharacter(); // Обновляем активного персонажа
    }

    public void SelectGenderRight()
    {
        genderIndex = (genderIndex - 1 + 2) % 2; // Переключаем пол
        PlayerPrefs.SetInt("SelectGender", genderIndex);
        UpdateCharacterArray();
        ActivateCurrentCharacter(); // Обновляем активного персонажа
    }

    public void SelectClassLeft()
    {
        classIndex = (classIndex + 1) % 3; // Переключаем класс
        PlayerPrefs.SetInt("SelectClass", classIndex);
        ActivateCurrentCharacter(); // Обновляем активного персонажа
    }

    public void SelectClassRight()
    {
        classIndex = (classIndex - 1 + 3) % 3; // Переключаем класс
        PlayerPrefs.SetInt("SelectClass", classIndex);
        ActivateCurrentCharacter(); // Обновляем активного персонажа
    }

    public void StartScene()
    {
        PlayerPrefs.SetInt("SelectGender", genderIndex);
        PlayerPrefs.SetInt("SelectClass", classIndex);
        PlayerPrefs.Save(); // Сохраняем данные
        SceneManager.LoadScene("Game_Terra");
    }
}