using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ghost_to_follow : MonoBehaviour
{
    public GameObject target_player;

    private NavMeshAgent agent;

    public float ghost_speed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (target_player == null)
        {
            target_player = GameObject.FindGameObjectWithTag("Player");
        }

    }
    private void Update()
    {
        agent.destination = target_player.transform.position ;
    }
}
