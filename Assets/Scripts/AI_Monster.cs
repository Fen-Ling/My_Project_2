using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Monster : MonoBehaviour
{
    private NavMeshAgent AI_Agent;
    private GameObject Player;
    public GameObject Panel_GaveOver;

    public Transform[] WayPoints;
    public int Current_Patch;
     public int attackDamage = 10;
    private int player_health = 100;
    private bool isAttacking = false;

    public enum AI_State { Patrol, Stay, Chase};
    public AI_State AI_Enemy;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (AI_Enemy == AI_State.Patrol)
        {
            // AI_Agent.Resume();
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            AI_Agent.SetDestination(WayPoints[Current_Patch].transform.position);
            float Patch_Dist = Vector3.Distance(WayPoints[Current_Patch].transform.position, gameObject.transform.position);
            if (Patch_Dist < 2)
            {
                Current_Patch++;
                Current_Patch = Current_Patch % WayPoints.Length;
            }
        }
        if (AI_Enemy == AI_State.Stay)
        {
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            // AI_Agent.Stop();
        }
        if (AI_Enemy == AI_State.Chase)
        {
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            AI_Agent.SetDestination(Player.transform.position);


        }

        float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (Dist_Player < 2)
        {
            AttackPlayer(attackDamage);
        }
        else if(Dist_Player > 20)
        {
            AI_Enemy = AI_State.Patrol;
        }
    
    }
    public void AttackPlayer(int damage)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Attack");
        player_health -= damage;
        if (player_health <= 0)
        {
            Player.SetActive(false);
            gameObject.GetComponent<Animator>().SetTrigger("Off");
            AI_Enemy = AI_State.Patrol; // Вернуться в состояние патрулирования
            // AI_Agent.ResetPath(); // Сбросить путь, чтобы враг не продолжал двигаться
        }
    }
}