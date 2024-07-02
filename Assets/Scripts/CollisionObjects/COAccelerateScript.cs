using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to all Accelerator objects.
public class COAccelerateScript : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private int eventFlag = 0;
    private const int ACCELERATE_TIME = 30;

    private Vector3 VECTOR = new Vector3(1.0f, 0.0f, 0.0f);

    private const float MAX_VELOCITY_Y = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GameObject.Find("Car_root").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // add force in the opposite direction for SLOWDOWN_TIME
        if (eventFlag % ACCELERATE_TIME != 0)
        {
            playerRigidbody.velocity += VECTOR * 0.5f;
            eventFlag++;
        }

        if (playerRigidbody.velocity.y > MAX_VELOCITY_Y) playerRigidbody.velocity += new Vector3(0.0f, -playerRigidbody.velocity.y + MAX_VELOCITY_Y, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // obtain the collision partner object
        if (eventFlag == 0 && collision.gameObject.tag == "Player")
        {
            eventFlag++;

            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}