// Ball that the paddles collide with. If the ball crosses either side of the screen, a point is scored on the opposite side.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Difficulty multipilier for each time the ball collides with a surface
    public float difficultyMultiplier = 1.2f;

    // Ball movement speed limits
    public float minXSpeed = 1.2f;
    public float maxXSpeed = 1.5f;
    public float minYSpeed = 1.2f;
    public float maxYSpeed = 1.5f;

    private Rigidbody2D ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Set the ball's velocity based on the speed limits, assigning a 50% chance of going either up or down, and left or right

        ballRigidBody = GetComponent<Rigidbody2D>();
        ballRigidBody.velocity = new Vector2
            (
            Random.Range(minXSpeed, maxXSpeed) * (Random.value > 0.5f ? -1 : 1), 
            Random.Range(minYSpeed, maxYSpeed) * (Random.value > 0.5f ? -1 : 1)
            );
    }

    void OnTriggerEnter2D (Collider2D otherCollider)
    {
        // If the ball collides with vertical screen limits, reverse its y-direction

        if (otherCollider.tag == "Limit")
        {
            GetComponent<AudioSource>().Play();
            
            if ((otherCollider.transform.position.y > transform.position.y) && (ballRigidBody.velocity.y > 0)) 
            // collided with top limit, moving up
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }

            if ((otherCollider.transform.position.y < transform.position.y) && (ballRigidBody.velocity.y < 0)) 
            // collided with bottom limit, moving down
            {
                ballRigidBody.velocity = new Vector2(ballRigidBody.velocity.x, -ballRigidBody.velocity.y);
            }
        }

        // If the ball collides with a paddle, reverse its x-direction

        else if (otherCollider.tag == "Paddle")
        {
            GetComponent<AudioSource>().Play();

            if ((otherCollider.transform.position.x < transform.position.x) && (ballRigidBody.velocity.x < 0))
            // collided with paddle, moving left
            {
                ballRigidBody.velocity = new Vector2
                    (-ballRigidBody.velocity.x * difficultyMultiplier, ballRigidBody.velocity.y * difficultyMultiplier);
            }

            if ((otherCollider.transform.position.x > transform.position.x) && (ballRigidBody.velocity.x > 0))
            // collided with paddle, moving right
            {
                ballRigidBody.velocity = new Vector2
                    (-ballRigidBody.velocity.x * difficultyMultiplier, ballRigidBody.velocity.y * difficultyMultiplier);
            }
        }
    }
}
