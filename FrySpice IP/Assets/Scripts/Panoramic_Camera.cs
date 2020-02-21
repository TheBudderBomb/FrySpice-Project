using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panoramic_Camera : MonoBehaviour
{
    /// <summary>
    /// Author: William T. Fry
    /// Created: 02/19/2020
    /// A script used for allowing the camera to follow the player associated with it.
    /// <params>A player object and Camera distance.</params>
    /// </summary>
    public Transform player;
    public float cam_dist = 30.0f;

    /// <summary>
    /// Method called when the script instance is being loaded, initializing the camera
    /// component and its size value
    /// </summary>
    void Awake()
    {
        //Accounts for camera size/screen height
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cam_dist);
    }

    /// <summary>
    /// Basically Frame-rate independent message for physics calculations, 
    /// has the frequency of the physics system; it is called every fixed 
    /// frame-rate frame.
    /// </summary>
    void FixedUpdate()
    {
        //Updates the camera's position
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
