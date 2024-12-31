using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Lvl : MonoBehaviour
{
    public float currentExp = 1;
    public int currentLvl = 1;
    public float expForNewLVL = 10;
    public Slider EXPBar;
    public TextMeshProUGUI Lvl_TXT;

    public void Start()
    {
        EXPBar.maxValue = expForNewLVL;
        EXPBar.value = currentExp;
        Lvl_TXT.text = currentLvl.ToString();
    }
    // private void Update()
    // {
    //     EXPBar.value = currentExp;
    // }

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
        expForNewLVL *= 1.5f;
        EXPBar.maxValue = expForNewLVL;
    }
}