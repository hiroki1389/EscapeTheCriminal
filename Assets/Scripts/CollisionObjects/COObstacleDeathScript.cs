using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to all Obstacle objects.
public class COObstacleDeathScript : MonoBehaviour
{
    private bool destroyFlag = false;
    private float elapsedTime = 0.0f;
    private const float ANIMTATION_TIME = 3.0f;

    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject obstacleBreak;

    // Start is called before the first frame update
    private void Start()
    {
        obstacleBreak.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (destroyFlag)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > ANIMTATION_TIME) obstacleBreak.gameObject.SetActive(false);
        }
    }

    // be called once in collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            destroyFlag = true;
            obstacle.gameObject.SetActive(false);
            obstacleBreak.gameObject.SetActive(true);
        }
    }
}
