using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Rai.
// attached to Criminal object in OpeningScene.
public class OpeningDestroyCriminalScript : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private const float ANIMATION_TIME = 5.0f;

    private void Start() { }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > ANIMATION_TIME) this.gameObject.SetActive(false);
    }
}