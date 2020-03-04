using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    public int lives;
    public int number_of_lives;

    public Image[] faces;
    public Sprite life;
    public Sprite no_life;

    bool dead;

    GameObject player;

    Vector3 og_pos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        og_pos = player.transform.position;
    }

    void Update()
    {
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

    public void Damage()
    {
        lives = lives - 1;
        //insert hurt sound byte here
        //Debug.Log("I registered some damage!");
        if (lives < 0 && !dead)
        {
            Death();
        } else
        {
            Respawn();
        }
    }

    void Respawn()
    {
        player.transform.position = og_pos;
    }

    void Death()
    {
        dead = true;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
