using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panoramic_Camera : MonoBehaviour
{
    //init of player
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (player.transform.position.x > -1)
            {
                if(player.transform.position.y > -1)
                {
                    transform.position = transform.position.y;
                }

                transform.position = transform.position.x;

            }
        }
    }
}
