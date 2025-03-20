using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public PlayerScript owner;
    public int location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<BallScript>() != null)
        {
            BallScript ball = collision.gameObject.GetComponentInChildren<BallScript>();
            GameManager.instance.Goal(ball.controller);
        }
    }
}
