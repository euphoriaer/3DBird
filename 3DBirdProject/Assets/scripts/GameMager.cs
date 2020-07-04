using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMager : MonoBehaviour
{
    public Transform onePosition;
    public Transform twoPosition;

    public Transform threePosition;
    public List<GameObject> creatGameObject;
    


    public float creatTime;
    private float timeTemp;
    private int creatNumber;

    // Start is called before the first frame update
    void Start()
    {
        timeTemp = creatTime;
        creatNumber = creatGameObject.Count;

    }

    // Update is called once per frame
    void Update()
    {
        RangeCreat();
        creatTime -= Time.deltaTime;
        

    }

    public void Creat(GameObject gameObject,Transform position)
    {


        Instantiate((gameObject), position);


    }

    public void RangeCreat()
    {
        if (creatTime <= 0)
        {
            float ranPTemp = Random.Range(1, 4);//达不到最大值
            int ranCTemp = Random.Range(0, creatNumber);

            Debug.Log(ranPTemp);
            if (ranPTemp == 1)
            {
               
                Creat(creatGameObject[ranCTemp],onePosition);


            }
            else if (ranPTemp == 2)
            {
                Creat(creatGameObject[ranCTemp], twoPosition);


            }
            else if (ranPTemp == 3)
            {
                Creat(creatGameObject[ranCTemp], threePosition);


            }
            creatTime = timeTemp;

        }
    }

}
