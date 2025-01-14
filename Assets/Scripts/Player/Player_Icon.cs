using UnityEngine;
using UnityEngine.UI;

public class Player_Icon : MonoBehaviour
{
    public Sprite[] sprites;

    [SerializeField]
    private Image currentIcon;

    void Start()
    {
        int index = 0;

        if (PlayerDataManager.playerData.genderIndex == 0)
        {
            index = PlayerDataManager.playerData.classIndex switch
            {
                0 => 0,
                1 => 1,
                2 => 2,
                _ => 0
            };
        }
        else
        {
            index = PlayerDataManager.playerData.classIndex switch
            {
                0 => 3,
                1 => 4,
                2 => 5,
                _ => 3
            };
        }

        currentIcon.sprite = sprites[index];
    }
}
