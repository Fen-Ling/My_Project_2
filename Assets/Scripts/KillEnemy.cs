
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public int enemyKillCount;
    private void Start()
    {
        enemyKillCount = PlayerDataManager.playerData.Kill;
    }

    public void IncreaseKillCount()
    {
        enemyKillCount++;
        Debug.Log("Уничтожено врагов: " + enemyKillCount);
    }

    public int GetKillCount()
    {
        return enemyKillCount;
    }
}