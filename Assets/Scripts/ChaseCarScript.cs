using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// created by Hiroki.
// attached to PoliceCarParent object which chases the criminal in MainScene.
public class ChaseCarScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody policeCarRigidBody;

    [SerializeField] private GameObject startEvent2;
    [SerializeField] private GameObject endEvent2;

    private const float START_CHASE_TIME = 10.0f;
    private float elapsedTime = 0.0f;

    [SerializeField] private float CHASE_SPEED = 60.0f;
    private const float LEFT_SPEED = 5.0f;
    private const float ANGULAR_FREQUENCY = 5.0f;

    private bool gameOverFlag = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root"); // Player object name
        policeCarRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(gameOverFlag) 
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            policeCarRigidBody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            return;
        }
        else
        {
            elapsedTime += Time.deltaTime * Time.timeScale;

            if (elapsedTime > START_CHASE_TIME)
            {
                policeCarRigidBody.velocity = new Vector3(CHASE_SPEED, 0.0f, LEFT_SPEED * (float)Math.Sin(elapsedTime * ANGULAR_FREQUENCY));
            }

            if (startEvent2.transform.position.x < this.transform.position.x && this.transform.position.x < endEvent2.transform.position.x)
            {
                policeCarRigidBody.velocity += new Vector3(0.0f, 0.0f, LEFT_SPEED);
            }

            if(player.transform.position.x < this.transform.position.x + 10.0f)
            {
                gameOverFlag = true;
                player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                policeCarRigidBody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }
}