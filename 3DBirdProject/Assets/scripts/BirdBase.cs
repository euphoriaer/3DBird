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

    public bool jumpKeyBool = false;
    public bool rightKeyBool = false;
    public bool leftKeyBool = false;
    public bool fastFlyBool = false;

    public Collider lost;

    public float coinUpSpeed;
    private GameMager GameMager;
    private Animator Animator;

    [Header("-----生命-----")]
    public Image Heart;

    [Header("-----重力感应移动速度-----")]
    public float speed = 10.0F;//方块移动速度

    private float jumpTime = 0;

    // Start is called before the first frame update
    private void Start()
    {
        GameMager = GameObject.Find("GameMager").GetComponent<GameMager>();
        Animator = GameObject.Find("bird").GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Keymap();
        BirdJump();
        RighAndLeftMove();
        Zvelocity();
        FastFly();
#if UNITY_ANDROID//条件编译 手机使用重力感应
        GravityInteraction();
#endif
    }

    private void Keymap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            jumpKeyBool = true;
            Debug.LogError("按下了按键");
            //if (Time.time - jumpTime <= 0.5f)  //跳跃间隔，增加云朵，不设置跳跃间隔
            //{
            //    Debug.LogError(Time.time - jumpTime);
            //    Debug.LogError("开始跳跃");
            //    jumpKeyB = true;
            //    jumpTime = 0;
            //}
            //else
            //{
            //       jumpTime = Time.time;
            //    jumpKeyB = false;
            //}
        }
        else
        {
            jumpKeyBool = false;
        }

        if (Input.GetKey(jumpKey))
        {
            jumpKeyBool = true;
            //if (Time.time - jumpTime <= 0.5f)  //跳跃间隔，增加云朵，不设置跳跃间隔
            //{
            //    Debug.LogError(Time.time - jumpTime);
            //    Debug.LogError("开始跳跃");
            //    jumpKeyBool = true;
            //    jumpTime = 0;
            //}
            //else
            //{
            //    jumpTime = Time.time;
            //    jumpKeyBool = false;
            //}

        }
        else
        {
            jumpKeyBool = false;
        }


        if (Input.GetKey(rightKey))
        {
            rightKeyBool = true;

        }
        else
        {
            rightKeyBool = false;
        }
        if (Input.GetKey(leftKey))
        {
            leftKeyBool = true;

        }
        else
        {
            leftKeyBool = false;
        }
        if (Input.GetKey(fastFly))
        {
            fastFlyBool = true;

        }
        else
        {
            fastFlyBool = false;
        }


    }

    public void BirdJump()
    {
        
        if (jumpKeyBool == true)
        {
            rigBird.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    public void Zvelocity()
    {
        if (fastFlyBool == false)
        {
            rigBird.velocity = new Vector3(rigBird.velocity.x, rigBird.velocity.y, 0);
        }
    }

    public void RighAndLeftMove()
    {
        if (leftKeyBool == true)
        {
            rigBird.AddForce(new Vector3(-moveForce, 0, 0));
            Debug.Log("left");
        }
        else
        {
            rigBird.velocity = new Vector3(0, rigBird.velocity.y, rigBird.velocity.z);
        }
        if (rightKeyBool == true)
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
        if (other.transform.tag == "Finish")
        {
            Debug.Log("游戏结束");
            GameMager.GameOver = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ceiling")
        {
            Debug.Log("有碰撞");
            Heart.fillAmount -= 0.33f;
            if (Heart.fillAmount <= 0.2f)
            {
                GameMager.GameOver = true;
            }
        }
        

    }

    /// <summary>
    /// 重力感应
    /// </summary>
    private void GravityInteraction()
    {
        Vector3 dir = Vector3.zero;//方块移动向量

        dir.x = Input.acceleration.x;

        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void FastFly()
    {
        if (fastFlyBool == true)
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