using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to Camera object.
public class AdjustCameraScript : MonoBehaviour
{
    private Transform transform;

    private const float MOVE_DISTANCE = 0.05f;

    private Quaternion currentRotation;
    private const float ROTATION_AMOUNT = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            transform.position += new Vector3(MOVE_DISTANCE, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.G))
            transform.position -= new Vector3(MOVE_DISTANCE, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.F))
            transform.position += new Vector3(0.0f, 0.0f, MOVE_DISTANCE);
        if (Input.GetKeyDown(KeyCode.H))
            transform.position -= new Vector3(0.0f, 0.0f, MOVE_DISTANCE);
        if (Input.GetKeyDown(KeyCode.PageUp))
            transform.position += new Vector3(0.0f, MOVE_DISTANCE, 0.0f);
        if (Input.GetKeyDown(KeyCode.PageDown))
            transform.position -= new Vector3(0.0f, MOVE_DISTANCE, 0.0f);


        currentRotation = transform.rotation;
        if (Input.GetKeyDown(KeyCode.R))
            currentRotation *= Quaternion.Euler(0.0f, -ROTATION_AMOUNT, 0.0f);
        if (Input.GetKeyDown(KeyCode.Y))
            currentRotation *= Quaternion.Euler(0.0f, ROTATION_AMOUNT, 0.0f);

        transform.rotation = currentRotation;
    }
}