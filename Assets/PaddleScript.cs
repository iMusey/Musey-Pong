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
        // Get Input From Player
        if (Input.GetKey(owner.left) && Input.GetKey(owner.right))
        {

        }
        else if (Input.GetKey(owner.left))
        {

        }
        else if (Input.GetKey(owner.right))
        {

        }

        
    }
}
