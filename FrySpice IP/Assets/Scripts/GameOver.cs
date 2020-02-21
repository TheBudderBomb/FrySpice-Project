using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// GUI method which creates the buttons used to exit the game or
    /// try it again from the beginning.
    /// </summary>
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 150, 100, 40), "Play Again?"))
        {
            SceneManager.LoadScene(0);
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 200, 100, 40), "Quit Game"))
        {
            Application.Quit();
        }
    }
}
