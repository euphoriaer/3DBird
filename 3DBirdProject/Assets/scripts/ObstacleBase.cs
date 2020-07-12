using UnityEngine;

public class ObstacleBase : MonoBehaviour
{
    public Transform obstacleMoveT;
    public float moveSpeed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //obstacleMoveT.position = new Vector3(obstacleMoveT.position.x, obstacleMoveT.position.y,
        //    obstacleMoveT.position.z * Time.deltaTime * moveSpeed);
        obstacleMoveT.position = new Vector3(obstacleMoveT.position.x, obstacleMoveT.position.y,
            obstacleMoveT.position.z + moveSpeed);
    }
}