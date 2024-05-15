
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float moveSpeed;
    public float minX;
    public float maxX;  // Minimum and maximum X positions, randomly generated

    private bool movingRight = true;
    private bool movingDown = false;
    private Rigidbody platformRb;
    private Vector3 lastPosition; // The position before the platform was updated
    private Vector3 lastMove; // The number of units moved between updates
    private float timer;
    private float duration = 3;
    public static float SpeedModifier = 0;
    public Countdown countdown;

    private void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        moveSpeed = Random.Range(4, 10); // Speed at which the platform moves
        minX = Random.Range(-8, 0);
        maxX = Random.Range(0, 8); //Values of min and Max position being declared as random

        countdown = FindAnyObjectByType<Countdown>();
    }


    void FixedUpdate()
    {
        // How much did ther platform move between frames?
        lastMove = platformRb.position - lastPosition;

        // Move the platform back and forth
        if (movingRight)
        {
            platformRb.MovePosition(platformRb.position + Vector3.right * (moveSpeed + SpeedModifier) * Time.deltaTime);

            if (transform.position.x >= maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            platformRb.MovePosition(platformRb.position + Vector3.left * (moveSpeed + SpeedModifier) * Time.deltaTime);

            if (transform.position.x <= minX)
            {
                movingRight = true;
            }
        }
        if (movingDown)
        {
            platformRb.MovePosition(platformRb.position + Vector3.down * moveSpeed * Time.deltaTime);
        }


        // Keep track of the new position / reset the variable
        lastPosition = platformRb.position;
    }

    // Will continue to work as long as the platform and player are touching
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody otherRb = collision.collider.attachedRigidbody;
        if (otherRb == null) // make sure we have a rigidbody to move
        {
            return;
        }

        otherRb.MovePosition(otherRb.position + lastMove);
        Crumble();

    }

    private void OnCollisionExit(Collision collision)
    {
        timer = 0;


    }
    void Crumble()
    {


        timer += Time.deltaTime;
        if (timer > duration)
        {
            movingDown = true;

        }
        countdown.UpdateCountdownText(duration - timer);

    }

}



