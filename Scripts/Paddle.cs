// Paddle that is controlled by the player to move vertically and interact with the ball (reverse its direction on contact)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 1f;        // paddle movement speed
    public int playerIndex = 1;   // player 1 or player 2

    // Update is called once per frame
    void Update()
    {
        // Set paddle velocity based on user input
        float verticalMovement = Input.GetAxis("Vertical" + playerIndex);
        GetComponent<Rigidbody2D>().velocity = new Vector2 (0, verticalMovement * speed);
    }
}
