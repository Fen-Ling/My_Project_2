using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Lvl : MonoBehaviour
{
    public float currentExp = 0;
    public int currentLvl = 1;
    public float expForNewLVL = 100;
    public Image EXPBar;
    public TextMeshProUGUI Lvl_TXT;

    public void Start()
    {
        currentExp = PlayerDataManager.playerData.curExp;
        currentLvl = PlayerDataManager.playerData.level;
        expForNewLVL = PlayerDataManager.playerData.ExpToLvl;

        // Инициализация значения EXPBar
        UpdateEXPBar();
        Lvl_TXT.text = currentLvl.ToString();
    }

    public void Experience(float EXP)
    {
        currentExp += EXP;
        if (currentExp >= expForNewLVL)
        {
            LevelUP();
        }
        UpdateEXPBar();
    }

    public void LevelUP()
    {
        currentLvl++;
        Lvl_TXT.text = currentLvl.ToString();

        currentExp -= expForNewLVL; // Уменьшаем текущий опыт на необходимый для левела
        expForNewLVL *= 2; // Увеличиваем необходимый опыт для следующего уровня
        UpdateEXPBar(); // Обновляем бар после левела
    }

    private void UpdateEXPBar()
    {
        float fillAmount = currentExp / expForNewLVL; // Процент заполнения
        EXPBar.fillAmount = fillAmount; // Устанавливаем заполнение Image
    }
}