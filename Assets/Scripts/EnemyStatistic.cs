using TMPro;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    public TextMeshProUGUI Kill_Text;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    private GameObject player;
    private Player_Lvl playerLevel;
    private Player_HP playerHealth;
    private EnemyStatistic enemyStatistics;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.GetComponent<Player_Lvl>();
        playerHealth = player.GetComponent<Player_HP>();
        
        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }
    public void IncreaseKillCount()
    {
        enemyKillCount++;
        UpdateKillText();
    }

    public int GetKillCount()
    {
        return enemyKillCount;
    }

    private void UpdateKillText()
    {
        Kill_Text.text = "Убийства: " + GetKillCount();
    }

    private void UpdateUI()
    {
        // Обновляем текстовые поля с текущими значениями
        hpText.text = "HP: " + playerHealth.HP;
        levelText.text = "LVL: " + playerLevel.currentLvl;
        expText.text = "EXP: " + playerLevel.currentExp;
        Kill_Text.text = "Убийства: " + GetKillCount();
    }
}
