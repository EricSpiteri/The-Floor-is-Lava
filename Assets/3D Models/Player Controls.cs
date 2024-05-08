
using UnityEngine;


public class PlayerControls : MonoBehaviour{

    //declaring physics variables and assigning their values
    public float speed = 8;
    public float jumpforce = 15;

    //declaring RigidBody
    private Rigidbody playerRb;
    bool grounded;

    //intitialising

    void Start(){
    
        //fetching Rigidbody
        playerRb = GetComponent <Rigidbody> ();

    }

    //what happens after initialisation

    void Update()
    {
  
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 direction = Vector3.zero;
        if (grounded == true)
        {
            direction = new Vector3(horizontal, 0, vertical).normalized * speed;
        }
        else { direction = new Vector3(horizontal, 0, vertical).normalized * speed*0.5f; }
        
        direction.y = playerRb.velocity.y;

        playerRb.velocity = direction;

        //Jump Mechanic
        if (Input.GetButtonDown("Jump") && (grounded == true))
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            
            
        } 
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
            MovingPlatform.SpeedModifier = 0;
            jumpforce+=1.5f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
            MovingPlatform.SpeedModifier = -5;
        }
    }
}
