using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numPlayers;

    // Start Conditions
    public float startForce;
    public Vector2[] startDirections;

    // Game Pieces
    public BallScript ball;

    // static declaration
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetUpPaddles(GameObject p1, GameObject p2, GameObject p3, GameObject p4)
    {
        if (p4 != null)
        {
            if (p3 != null)
            {
                // 3 player setup goes
                // here
            }

            // 4 player setup goes
            // here
        }
        
        // 2 player setup

        
    }

    void TipBall()
    {
        // Determine Direction
        int dir1 = Random.Range(0, 2) * 2 - 1;
        int dir2 = Random.Range(0, 2) * 2 - 1;

        // Create force vector
        int vNum = Random.Range(0,startDirections.Length-1);
        Vector2 tipForce = startForce * startDirections[vNum].normalized;
        tipForce = new Vector2 (dir1 * tipForce.x, dir2 * tipForce.y);

        // Apply force to ball
        ball.rb.AddForce(tipForce);
    }

    void StartRound()
    {
        // Reset Ball
        if (ball != null)
        {
            Destroy(ball);
        }
        ball = Instantiate(OmnipotentOne.instance.ballPFab).GetComponent<BallScript>();

        TipBall();
    }

    public void Goal(PlayerScript scorer)
    {
        scorer.wins++;
        StartRound();
    }
}
