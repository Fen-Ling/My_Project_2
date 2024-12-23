using UnityEngine;
using Unity.Cinemachine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] maleCharacters;
    public GameObject[] femaleCharacters;
    private int genderIndex;
    private int classIndex;
    private GameObject[] currentCharacters;
    private CinemachineCamera virtualCamera;

    private void Start()
    {

        genderIndex = PlayerPrefs.GetInt("SelectGender");
        classIndex = PlayerPrefs.GetInt("SelectClass");

        UpdateCharacterArray();
        ActivateCurrentCharacter();
        RemoveInactiveCharacters(currentCharacters, classIndex);

        // AssignPlayerToCamera();
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

    // private void AssignPlayerToCamera()
    // {
    //     // Получаем компонент CinemachineVirtualCamera
    //     virtualCamera = GameObject.;

    //     // Находим игрока по тегу
    //     GameObject player = GameObject.FindGameObjectWithTag("Player");
    //     if (player != null)
    //     {
    //         // Присваиваем игрока в качестве Tracking Target
    //         virtualCamera.Follow = player.transform;
    //         virtualCamera.LookAt = player.transform; // Если нужно, чтобы камера смотрела на игрока
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Игрок с тегом 'Player' не найден!");
    //     }
    // }
}
