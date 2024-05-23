using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Winning : MonoBehaviour// used to attach a script to a game object
{
    public ScoreManager scoreManager;

             // call on trigger method
             // a message that is called when a gameobject touches a trigger collider
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            PlayerControls Controls = other.GetComponent<PlayerControls>();
            Controls.ResetPosition();
            MovingPlatform.moveSpeed = Random.Range(6, 12); // Resetting random Values
            MovingPlatform.minX = Random.Range(-8, 0);
            MovingPlatform.maxX = Random.Range(0, 8);
 


            Debug.Log("You Win");
            
 
            
            
            
            
            


        }
    }
}