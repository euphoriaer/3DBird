using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public  Transform obstacleMoveT;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //obstacleMoveT.position = new Vector3(obstacleMoveT.position.x, obstacleMoveT.position.y,
        //    obstacleMoveT.position.z * Time.deltaTime * moveSpeed);
        obstacleMoveT.position = new Vector3(obstacleMoveT.position.x, obstacleMoveT.position.y,
            obstacleMoveT.position.z + moveSpeed);


    }
}
