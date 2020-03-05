using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    /// <summary>
    /// Author: William T Fry
    /// Created: 03/05/2020
    /// Desc: Script used for managing lives counters and logic, 
    /// as well as respawning and death.
    /// </summary>
    public int lives;
    public int number_of_lives;

    public Image[] faces;
    public Sprite life;
    public Sprite no_life;

    bool dead;

    GameObject player;
    PlayerController p_control;

    Vector3 og_pos;

    /// <summary>
    /// Grabs a player tagged object for manipulation, finds its 
    /// position for respawning
    /// </summary>
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        og_pos = player.transform.position;
        p_control = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        //Lives Logic
        if (lives > number_of_lives)
        {
            lives = number_of_lives;
        }

        for (int i = 0; i < faces.Length; i++)
        {
            if(i < lives)
            {
                faces[i].sprite = life;
            } else
            {
                faces[i].sprite = no_life;
            }

            if (i < number_of_lives)
            {
                faces[i].enabled = true;
            } else
            {
                faces[i].enabled = false;
            }
        }
        Debug.Log(lives);
    }

    /// <summary>
    /// Unique function for calculating the damage on the player
    /// </summary>
    public void Damage()
    {
        lives = lives - 1;
        //insert hurt sound byte here
        if (lives < 0 && !dead)
        {
            Death();
        } else
        {
            Respawn();
            p_control.Vulnerability();

        }
    }

    /// <summary>
    /// Unique function for respawning the player
    /// </summary>
    void Respawn()
    {
        player.transform.position = og_pos;
    }

    /// <summary>
    /// Unique function for killing the player
    /// </summary>
    void Death()
    {
        dead = true;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
