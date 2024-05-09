using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaDeath : MonoBehaviour// used to attach a script to a game object
{

             // call on trigger method
             // a message that is called when a gameobject touches a trigger collider
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {

            Debug.Log("You Died");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}