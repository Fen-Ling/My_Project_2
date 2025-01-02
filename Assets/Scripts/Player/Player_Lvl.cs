using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Lvl : MonoBehaviour
{
    public float currentExp = 0;
    public int currentLvl = 1;
    public float expForNewLVL = 100;
    public Slider EXPBar;
    public TextMeshProUGUI Lvl_TXT;

    public void Start()
    {
        currentExp = PlayerDataManager.playerData.curExp;
        currentLvl = PlayerDataManager.playerData.level;
        expForNewLVL = PlayerDataManager.playerData.ExpToLvl;

        EXPBar.maxValue = expForNewLVL;
        EXPBar.value = currentExp;
        Lvl_TXT.text = currentLvl.ToString();


    }
    public void Experience(float EXP)
    {
        currentExp += EXP;
        if (currentExp > expForNewLVL)
        {
            LevelUP();
        }
        EXPBar.value = currentExp;
    }
    public void LevelUP()
    {
        currentLvl++;
        Lvl_TXT.text = currentLvl.ToString();

        currentExp -= expForNewLVL;
        expForNewLVL *= 2;
        EXPBar.maxValue = expForNewLVL;
    }
}