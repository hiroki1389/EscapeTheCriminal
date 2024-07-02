using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to Car_root object.
public class AEGameSpeedScript : MonoBehaviour
{
    // become true during collision avoidance event
    private float gameSpeed = 1.0f;

    // Start is called before the first frame update
    private void Start() { }
    
    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
        //Debug.Log(Time.timeScale);
    }

    // access this function from the obstacle to turn the flag on
    public void SetSpeed(float speed)
    {
        Debug.Log("setSpeed: " + speed);
        gameSpeed = speed;
    }
}
