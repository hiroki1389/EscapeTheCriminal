using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Takanaga.
// attached to all rubble objects.
//rigidbody→Constrains→freeze positionのx,zにチェック入れる
public class ResetLocation : MonoBehaviour
{
    private Transform playerTransform;

    private Vector3 startPosition;
    private const float POSITION_Y_START = 5.3f;
    [SerializeField] private float SAY = 0.0f; // 差Y

    private const float HIDE_DISTANCE = 2.0f;
    private const float DISTANCE = 500.0f;

    [SerializeField] private GameObject end;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.Find("Car_root").transform;

        startPosition = new Vector3(transform.position.x, POSITION_Y_START + SAY, transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if(this.transform.position.x + HIDE_DISTANCE < playerTransform.position.x
        && this.transform.position.x + DISTANCE < end.transform.position.x)
            this.transform.position += new Vector3(DISTANCE, 0.0f,0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.position = startPosition;
    }
}