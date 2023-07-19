using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_follew : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
       // Vector3 follow_move = new Vector3(player.position.x - transform.position.x, 106,player.position.z - transform.position.z);
    }

    private void LateUpdate()
    {
       // transform.position = player.position;
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z-32);
        
    }
}
