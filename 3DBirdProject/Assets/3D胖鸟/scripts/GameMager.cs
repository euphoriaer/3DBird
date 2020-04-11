using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMager : MonoBehaviour
{
    public Transform onePosition;
    public Transform twoPosition;

    public Transform threePosition;
    public GameObject creatGameObject;


    public float creatTime;
    private float timeTemp;

    // Start is called before the first frame update
    void Start()
    {
        timeTemp = creatTime;

    }

    // Update is called once per frame
    void Update()
    {
        RangeCreat();
        creatTime -= Time.deltaTime;
        

    }

    public void Creat(Transform position)
    {


        Instantiate((creatGameObject), position);


    }

    public void RangeCreat()
    {
        if (creatTime <= 0)
        {
            float cTemp = Random.Range(1, 4);//达不到最大值

            Debug.Log(cTemp);
            if (cTemp == 1)
            {
                Creat(onePosition);


            }
            else if (cTemp == 2)
            {
                Creat(twoPosition);


            }
            else if (cTemp == 3)
            {
                Creat(threePosition);


            }
            creatTime = timeTemp;

        }
    }

}
