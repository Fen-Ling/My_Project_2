using Unity.Cinemachine;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject[] maleCharacters;
    public GameObject[] femaleCharacters;
    public int genderIndex;
    public int classIndex;
    private GameObject[] currentCharacters;
    public CinemachineCamera cinemachineCamera;
    private GameObject player;

    private void Start()
    {
        genderIndex = PlayerDataManager.playerData.genderIndex;
        classIndex = PlayerDataManager.playerData.classIndex;

        UpdateCharacterArray();
        ActivateCurrentCharacter();
        RemoveInactiveCharacters(currentCharacters, classIndex);
        CameraTarget();
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
            player = currentCharacters[classIndex]; // Сохраняем ссылку на активированного персонажа
            player.SetActive(true);
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

    private void CameraTarget()
    {
        if (cinemachineCamera != null && player != null)
        {
            cinemachineCamera.Follow = player.transform;
        }
        else
        {
            Debug.LogError("CinemachineVirtualCamera или Player не найдены!");
        }
    }
}
