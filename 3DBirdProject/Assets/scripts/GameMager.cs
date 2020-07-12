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

    // Start is called before the first frame update
    private void Start()
    {
        timeTemp = creatTime;
        creatNumber = creatGameObject.Count;
        positonNumber = ranPositon.Count;
        text = GameObject.Find("score").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        RangeCreat();
        creatTime -= Time.deltaTime;
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

    public void Creat(GameObject gameObject, Transform position)
    {
        Instantiate((gameObject), position);
    }

    public void RangeCreat()
    {
        if (creatTime <= 0)
        {
            int ranPTemp = Random.Range(0, positonNumber);//达不到最大值
            int ranCTemp = Random.Range(0, creatNumber);

            Debug.Log(ranPTemp);

            Creat(creatGameObject[ranCTemp], ranPositon[ranPTemp]);

            creatTime = timeTemp;
        }
    }

    public void GameLevel()
    {
        if (creatTime >= 0.05)
        {
            creatTime -= (GamelevelTime / (100 / GameLevels));
        }
    }
}