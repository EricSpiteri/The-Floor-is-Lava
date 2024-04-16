using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 8f; // Speed at which the platform moves
    public float minX = 0;
    public float maxX = 10; // Minimum and maximum X positions

    private bool movingRight = true;
    private Rigidbody platformRb;

    private Vector3 lastPosition; // The position before the platform was updated
    private Vector3 lastMove; // The number of units moved between updates

    private void Start()
    {
        platformRb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // How much did ther platform move between frames?
        lastMove = platformRb.position - lastPosition;

        // Move the platform back and forth
        if (movingRight)
        {
            platformRb.MovePosition(platformRb.position + Vector3.right * moveSpeed * Time.deltaTime);

            if (transform.position.x >= maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            platformRb.MovePosition(platformRb.position + Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x <= minX)
            {
                movingRight = true;
            }
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
    }
}

