using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Kill : MonoBehaviour
{
    /// <summary>
    /// Author: William T. Fry
    /// Created: 02/19/2020
    /// A script that powers the 'destroyers' or the points by which the player will lose a life.
    /// </summary>


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Trigger method, tells the game when something crosses the line of the destroyer.
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the trigger happens to be tagged as a 'Player', does this.
        if (other.tag == "Player")
        {
            Debug.Break();
            return;
        }

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        } else {
            Destroy(other.gameObject);
        }
    }
}
