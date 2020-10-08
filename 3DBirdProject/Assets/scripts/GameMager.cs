using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMager : MonoBehaviour
{
    public List<Transform> ranPositon;

    public List<GameObject> creatGameObject;

    public Text text;

    public float creatTime;

    public float GamelevelTime;

    public int GameLevels = 1;

    private bool gameOver = false;

    private float timeTemp;
    private int creatNumber;
    private int positonNumber;
    private float score = 0;

    public bool GameOver { get => gameOver; set => gameOver = value; }
    public int CoinRotation { get => coinRotationSpeed; set => coinRotationSpeed = value; }

    public int coinRotationSpeed;

    [Header("云朵")]
    public List<GameObject> clouds;
    public List<Transform> cloudPosition;
    public float creTimeCloud;
    [Header("环境")]
    public List<GameObject> environment;
    // Start is called before the first frame update
    private void Start()
    {
        creatNumber = creatGameObject.Count;
        positonNumber = ranPositon.Count;
        text = GameObject.Find("score").GetComponent<Text>();
        InvokeRepeating(nameof(RepeatCloud), 0.5f, creTimeCloud);
        InvokeRepeating(nameof(RepeatItem), 0.5f, creatTime);
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameOver == true)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
        score += Time.fixedDeltaTime;
        text.text = ((int)score).ToString();
        GamelevelTime += Time.fixedDeltaTime;
    }


    private void RepeatItem()
    {
        RangeCreat(creatGameObject, ranPositon);//对地面障碍物随机创造
    }

    private void RepeatCloud()
    {
        RangeCreat(clouds, cloudPosition);//对云朵随机创造

    }
    /// <summary>
    /// 随机进行创造
    /// </summary>
    /// <param name="item">需要创造的物体列表</param>
    /// <param name="itemPosition">创造的位置列表</param>
    public void RangeCreat(List<GameObject> item,List<Transform> itemPosition)
    {
        
            int ranPTemp = Random.Range(0, itemPosition.Count);//达不到最大值
            int ranCTemp = Random.Range(0, item.Count);

            Debug.Log(ranPTemp);

            Instantiate(item[ranCTemp], itemPosition[ranPTemp]);

        
    }

    public void GameLevel()
    {
        if (creatTime >= 0.05)
        {
            creatTime -= (GamelevelTime / (100 / GameLevels));
        }
    }
}