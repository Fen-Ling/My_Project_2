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

    public enum AI_State { Patrol, Stay, Chase};
    public AI_State AI_Enemy;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (AI_Enemy == AI_State.Patrol)
        {
            // AI_Agent.Resume();
            gameObject.GetComponent<Animator>().SetBool("Patroll", true);
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
            gameObject.GetComponent<Animator>().SetBool("Patroll", false);
            // AI_Agent.Stop();
        }
        if (AI_Enemy == AI_State.Chase)
        {
            gameObject.GetComponent<Animator>().SetBool("Patroll", true);
            AI_Agent.SetDestination(Player.transform.position);
        }


        float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (Dist_Player < 2)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
            // Player.SetActive(false);
            // Panel_GaveOver.SetActive(true);
        }
    }
}