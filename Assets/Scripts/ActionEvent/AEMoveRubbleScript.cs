using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Yamada.
// attached to rubble objects of the car fire event in MainScene.
public class AEMoveRubbleScript : MonoBehaviour
{
    private int count = 0;

    private Transform myTransform;

    // Start is called before the first frame update
    private void Start()
    { 
        myTransform = this.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (count < 20) myTransform.position -= new Vector3(0.0f, 0.0f, 0.02f);

        count++;
    }
}
