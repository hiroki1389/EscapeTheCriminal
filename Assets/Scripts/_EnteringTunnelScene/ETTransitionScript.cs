using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to BlackImage object in EnteringTunnelScene.
public class ETTransitionScript : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    [SerializeField] private TransitNextSceneScript transitNextSceneScript;
    private string SCENE_NAME = "MainScene";
    private const float ANIMATION_TIME = 7.0f;

    private void Start() { }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > ANIMATION_TIME - transitNextSceneScript.ReturnTransitionTime())
            transitNextSceneScript.TransitNextScene(SCENE_NAME);
    }
}