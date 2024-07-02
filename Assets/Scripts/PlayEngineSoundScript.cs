using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Takanaga.
// attached to Engine objects which are children of Car_root.
public class PlayEngineSoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private GameObject player;
    private Rigidbody playerRigidbody;
    private float velocityX;

    private const float TRIM_SPEED = 30.0f;
    private const float MAX_SPEED = 240.0f;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        velocityX = playerRigidbody.velocity.x;

        audioSource.pitch = 1.0f + 17.3f * (velocityX/MAX_SPEED) - 1.5f * (int)(velocityX/TRIM_SPEED);
    }
}