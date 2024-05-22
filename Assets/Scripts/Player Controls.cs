
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerControls : MonoBehaviour{

    //declaring physics variables and assigning their values
    public static float speed = 8;
    public static float currentSpeed;

    public static float jumpforce = 15;
    public static float CurrentJumpforce = 1;
     public static float points = 1;
     public static float temppoints = 1;
    Vector3 StartingPosition;

     private AudioSource source;

    Animator PlayerAnim;



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
        temppoints = 1;
    }

    //what happens after initialisation

    void Update()
    {
        
        PlayerAnim =  GetComponentInChildren <Animator>();
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = Vector3.zero;
        if (Grounded == true)
        {
            
            direction = new Vector3(horizontal, 0, vertical).normalized * currentSpeed;
        }
        else { direction = new Vector3(horizontal, 0, vertical).normalized * currentSpeed;
            
        }
        
        direction.y = playerRb.velocity.y;

        playerRb.velocity = direction;

        //Jump Mechanic
        if (Input.GetButtonDown("Jump") && (Grounded == true))
        {
            playerRb.AddForce(Vector3.up * CurrentJumpforce, ForceMode.Impulse);
            source.Play();
        }

        PlayerAnim.SetBool("Run", Grounded && playerRb.velocity.magnitude>0);
        PlayerAnim.SetBool("Jump", !Grounded);
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
            CurrentJumpforce+= 2*(temppoints);
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
            MovingPlatform.SpeedModifier = -5*temppoints;
            currentSpeed-= 0.5f*temppoints;
            
            

        }
    }
}
