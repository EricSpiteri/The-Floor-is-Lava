using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerControls : MonoBehaviour{

    //declaring physics variables and assigning their values
    public float speed = 8;
    public float currentSpeed;
    public float jumpforce = 15;
    public float CurrentJumpforce;
     public float points = 1;
    Vector3 StartingPosition;

     private AudioSource source;

     

    //declaring RigidBody
    private Rigidbody playerRb;
    public static bool Grounded;

    //intitialising

    void Start(){
    
        //fetching Rigidbody
        playerRb = GetComponent <Rigidbody> ();
        source = GetComponent<AudioSource>();
        StartingPosition = playerRb.position;
        CurrentJumpforce = jumpforce;
        currentSpeed = speed;

    }

    public void ResetPosition()
    {
        playerRb.MovePosition(StartingPosition);
        CurrentJumpforce = jumpforce;
        currentSpeed = speed;
    }

    //what happens after initialisation

    void Update()
    {
        
  
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = Vector3.zero;
        if (Grounded == true)
        {
            direction = new Vector3(horizontal, 0, vertical).normalized * currentSpeed;
        }
        else { direction = new Vector3(horizontal, 0, vertical).normalized * currentSpeed; }
        
        direction.y = playerRb.velocity.y;

        playerRb.velocity = direction;

        //Jump Mechanic
        if (Input.GetButtonDown("Jump") && (Grounded == true))
        {
            playerRb.AddForce(Vector3.up * CurrentJumpforce, ForceMode.Impulse);
            source.Play();
            
            
        } 
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Grounded = true;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            MovingPlatform.SpeedModifier = 0;
            CurrentJumpforce+= 2*(points);
            FindObjectOfType<ScoreManager>().IncrementScore(points);
        }
    }

  

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Grounded = false;
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            MovingPlatform.SpeedModifier -= points;
            currentSpeed-= 0.5f*(points);
            

        }
    }
}
