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
    private KillEnemy killEnemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = player.GetComponent<Player_Lvl>();
        playerHealth = player.GetComponent<Player_HP>();
        killEnemy = player.GetComponentInParent<KillEnemy>();

        UpdateUI();
    }
    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        hpText.text = "HP: " + playerHealth.HP;
        levelText.text = "LVL: " + playerLevel.currentLvl;
        expText.text = "EXP: " + playerLevel.currentExp;
        Kill_Text.text = "Убийства: " + killEnemy.enemyKillCount;
    }
}
