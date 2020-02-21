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

    public static int lives;

    /// <summary>
    /// Method called on the frame when a script is enabled just before
    /// any of the Update methods are called the first time.
    /// </summary>
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
    }

    /// <summary>
    /// Trigger method, tells the game when something crosses the line of the destroyer.
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        //If the trigger happens to be tagged as a 'Player', does this.
        if (other.tag == "Player")
        {
            lives--;
            if (lives < 0)
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(1);
            } else
            {
                SceneManager.LoadScene(0);
                PlayerPrefs.SetInt("lives", lives);
            }

        }

        if (other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        } 
        else {
            Destroy(other.gameObject);
        }
    }
}
