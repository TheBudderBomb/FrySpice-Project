using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall_Kill : MonoBehaviour
{
    /// <summary>
    /// Author: William T. Fry
    /// Created: 02/19/2020
    /// A script that powers the 'destroyers' or the points by which the player will lose a life.
    /// </summary>

    Lives lives;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lives = player.GetComponent<Lives>();
    }

    /// <summary>
    /// Trigger method, tells the game when something crosses the line of the destroyer.
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the collision happens to be tagged as a 'Player', does this.
        if (other.gameObject.tag == "Player")
        {
            if(lives.lives >= 0)
            {
                lives.Damage();
            }
        }
        /*
        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        } 
        else {
            Destroy(other.gameObject);
        }*/
    }
}
