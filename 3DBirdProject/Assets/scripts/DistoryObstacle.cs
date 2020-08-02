using UnityEngine;

public class DistoryObstacle : MonoBehaviour
{
    public LayerMask obstacle;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject.Destroy(other.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject.Destroy(collision.other.gameObject);
    }
}