// Functionality to keep track of players' scores and spawn the ball at the start of each game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Ball game object and score text objects
    public GameObject ballPrefab;             
    public Text score1Text;                           
    public Text score2Text;      
    
    // Location on the screen that the ball must pass for the score to be incremented
    public float scoreCoordinates = 3.4f;

    // Ball object and player scores
    private Ball currentBall;
    private int score1 = 0;
    private int score2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();        // spawn the ball at the start of each game
    }

    void SpawnBall()
    {
        // Spawn the ball at the center of the screen and display player scores

        GameObject ballInstance = Instantiate(ballPrefab, transform);

        currentBall = ballInstance.GetComponent<Ball>();
        currentBall.transform.position = Vector3.zero;

        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /* Check if ball's position exceeds scoreCoordinate limit on either side of the screen, 
            update scores, destroy the ball once a point is scored, and spawn a new ball */

        if (currentBall != null)
        {
            if (currentBall.transform.position.x > scoreCoordinates)
            {
                score1++;
                Destroy(currentBall.gameObject);
                SpawnBall();
            }
            if (currentBall.transform.position.x < -scoreCoordinates)
            {
                score2++;
                Destroy(currentBall.gameObject);
                SpawnBall();
            }
        }
    }
}
