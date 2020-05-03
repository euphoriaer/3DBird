using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BirdBase : MonoBehaviour
{
    public Rigidbody rigBird;
    public float jumpForce;
    public string jumpKey;

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
    }

    public void BirdJump()
    {
        rigBird.AddForce(new Vector3(0, jumpForce, 0));
    }


}
