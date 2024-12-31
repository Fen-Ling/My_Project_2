using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Lvl : MonoBehaviour
{
    public float CorEXP = 1;
    public int lvl = 1;
    public float LVL_EXP = 10;
    public Slider EXPBar;
    public TextMeshProUGUI Lvl_TXT;

    public void Start()
    {
        EXPBar.maxValue = LVL_EXP;
        EXPBar.value = CorEXP;
        Lvl_TXT.text = lvl.ToString();
    }
    private void Update()
    {
        EXPBar.value = CorEXP;
    }

    public void Experience(float EXP)
    {
        CorEXP += EXP;
        LevelUP();
    }
    public void LevelUP()
    {
        if (CorEXP > LVL_EXP)
        {
            lvl++;
            CorEXP -= LVL_EXP;
            EXPBar.value = CorEXP;
            LVL_EXP = LVL_EXP * 1.5f;
            Lvl_TXT.text = lvl.ToString();
        }
    }
}