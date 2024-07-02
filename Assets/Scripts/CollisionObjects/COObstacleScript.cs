using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to all Obstacle objects.
public class COObstacleScript : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private bool eventFlag = false;

    private Vector3 VECTOR = new Vector3(-1.0f, 0.0f, 0.0f);
    private const float FORCE_MAGNITUDE = 10.0f;
    private float velocityX;

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GameObject.Find("Car_root").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() { }

    // be called once in collision
    private void OnCollisionEnter(Collision collision)
    {
        // obtain the collision partner object
        if (!eventFlag && collision.gameObject.tag == "Player")
        {
            eventFlag = true;
            this.GetComponent<BoxCollider>().enabled = false;

            velocityX = playerRigidbody.velocity.x;
            playerRigidbody.AddForce(VECTOR * velocityX * FORCE_MAGNITUDE, ForceMode.Acceleration);
        }
    }
}