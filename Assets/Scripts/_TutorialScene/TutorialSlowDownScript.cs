using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to ActionObstacle object in TutorialScene.
public class TutorialSlowDownScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rigidbody;

    private bool eventFlag = false;

    [SerializeField] private float SLOW_DOWN_RATE = 0.3f;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        rigidbody = player.GetComponent<Rigidbody>();
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

            rigidbody.velocity *= SLOW_DOWN_RATE;
        }
    }
}
