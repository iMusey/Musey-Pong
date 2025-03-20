using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public PlayerScript owner;
    public float power;
    public float speed;

    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Make movement vector
        Vector2 moveVec = Vector2.zero;

        // Get Input From Player
        // the direction changes based on the player number
        // the assumed direction is bottom middle looking up. so left moves it left and right moves right. but usually the position will be adjusted for 2 player
        if (Input.GetKey(owner.left) && Input.GetKey(owner.right))
        {
            // dont move?
        }
        else if (Input.GetKey(owner.left))
        {
            moveVec.x = -100;
        }
        else if (Input.GetKey(owner.right))
        {
            moveVec.x = 100;
        }


        // move towards
        transform.position = Vector2.MoveTowards(transform.position, moveVec, speed * Time.deltaTime);
    }

    Vector2 ChangePlayerDirection(Vector2 vec, int pN)
    {
        Vector2 newVec = Vector2.zero;

        if (pN == 1)
        {
            // p1 is on the left of the screen, change the direction and axis
            newVec.y = -vec.x;

        }
        else if (pN == 2)
        {
            // p2 is on the right so you just change the axis.
            newVec.y = vec.x;

        }


        return newVec;
    }
}
