using UnityEngine;
using UnityEngine.UI;

public class BirdBase : MonoBehaviour
{
    public Rigidbody rigBird;
    public float jumpForce;
    public float moveForce;
    public float fastForce;

    public string jumpKey;
    public string rightKey;
    public string leftKey;
    public string fastFly;

    public Button left;

    public bool jumpKeyB = false;
    public bool rightKeyB = false;
    public bool leftKeyB = false;
    public bool fastFlyB = false;

    public Collider lost;

    public float coinUpSpeed;
    private GameMager GameMager;
    private Animator Animator;

    private void GetKey()
    {
        //if (Input.GetKeyDown(jumpKey))
        //{
        //    jumpKeyB = true;
        //}
        //else
        //{
        //    jumpKeyB = false;
        //}
        //if (Input.GetKey(leftKey))
        //{
        //    leftKeyB = true;
        //}
        //else
        //{
        //    leftKeyB = false;
        //}
        //if (Input.GetKey(rightKey))
        //{
        //    rightKeyB = true;
        //}
        //else
        //{
        //    rightKeyB = false;
        //}

        //if (Input.GetKey(fastFly))
        //{
        //    fastFlyB = true;
        //}
        //else
        //{
        //    fastFlyB = false;
        //}
    }

    // Start is called before the first frame update
    private void Start()
    {
        GameMager = GameObject.Find("GameMager").GetComponent<GameMager>();
        Animator = GameObject.Find("bird").GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetKey();

        BirdJump();

        RighAndLeftMove();
        Zvelocity();
        FastFly();
    }

    public void BirdJump()
    {
        if (jumpKeyB == true)
        {
            rigBird.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    public void Zvelocity()
    {
        if (fastFlyB == false)
        {
            rigBird.velocity = new Vector3(rigBird.velocity.x, rigBird.velocity.y, 0);
        }
    }

    public void RighAndLeftMove()
    {
        if (leftKeyB == true)
        {
            rigBird.AddForce(new Vector3(-moveForce, 0, 0));
            Debug.Log("left");
        }
        else
        {
            rigBird.velocity = new Vector3(0, rigBird.velocity.y, rigBird.velocity.z);
        }
        if (rightKeyB == true)
        {
            rigBird.AddForce(new Vector3(moveForce, 0, 0));
            Debug.Log("right");
        }
        else
        {
            rigBird.velocity = new Vector3(0, rigBird.velocity.y, rigBird.velocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == lost)
        {
            GameMager.GameOver = true;
        }
    }

    public void FastFly()
    {
        if (fastFlyB == true)
        {
            Animator.SetBool("fastfly", true);
            rigBird.AddForce(0, 0, fastForce);
        }
        else
        {
            Animator.SetBool("fastfly", false);
        }
    }
}