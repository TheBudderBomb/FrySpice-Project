using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    /*
    Author: Joshua Schmitz
    Date: Feb 19, 2020
    Description: Portal script for when player touches portal allows player to 
    teleport to new location determined by portal
    */
    public GameObject myPortal;
    public GameObject Player;
    

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine (Teleport());
        }
    }

    IEnumerator Teleport(){
        yield return new WaitForSeconds (0);
        Player.transform.position = new Vector2(myPortal.transform.position.x,myPortal.transform.position.y);
    }
}
