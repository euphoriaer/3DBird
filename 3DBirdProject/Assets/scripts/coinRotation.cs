﻿using UnityEngine;
using UnityEngine.UI;

public class coinRotation : MonoBehaviour
{
    public Transform ro;
    private float roTime;
    private int roSpeed;
    public Collider bird;
    public GameMager GameMager;
    public Rigidbody Rigidbody;
    public float upSpeed;

    public Text coinNumber;

    // Start is called before the first frame update
    private void Start()
    {
        coinNumber = GameObject.Find("coinNumber").GetComponent<Text>();
        bird = GameObject.Find("bird").GetComponent<BoxCollider>();
        GameMager = GameObject.Find("GameMager").GetComponent<GameMager>();
        ro = this.gameObject.transform;
        roSpeed = GameMager.coinRotationSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        roTime += Time.deltaTime * 100 * roSpeed;
        ro.rotation = Quaternion.Euler(new Vector3(0, roTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bird)
        {
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, upSpeed, Rigidbody.velocity.z);
            coinNumber.text = (float.Parse(coinNumber.text) + 1f).ToString();
            GameObject.Destroy(this.gameObject, 0.15f);
        }
    }
}