using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BirdBase : MonoBehaviour
{
    public Rigidbody rigBird;
    public float jumpForce;
    public float moveForce;
    
    public string jumpKey;
    public string rightKey;
    public string leftKey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            BirdJump();

        }
        
        RighAndLeftMove();




    }

    public void BirdJump()
    {
        rigBird.AddForce(new Vector3(0, jumpForce, 0));
    }

    public void RighAndLeftMove()
    {
        if (Input.GetKey(leftKey))
        {
            rigBird.AddForce(new Vector3(-moveForce, 0, 0));
            Debug.Log("left");
        }
        else
        {
            rigBird.velocity = new Vector3(0, rigBird.velocity.y, rigBird.velocity.z);
        }
        if (Input.GetKey(rightKey))
        {
            rigBird.AddForce(new Vector3(moveForce, 0, 0));
            Debug.Log("right");
        }
        else
        {
            rigBird.velocity = new Vector3(0, rigBird.velocity.y, 0);
        }
    }
}
