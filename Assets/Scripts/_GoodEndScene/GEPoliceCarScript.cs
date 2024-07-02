using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Rai.
// attached to Interceptor object in GoodEndScene.
public class GEPoliceCarScript : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private const float START_ANIMATION_TIME = 12.0f;
    private const float ANIMATION_TIME = 30.0f;

    private const string SCENE_NAME = "ScoreScene";

    private float positionY;

    private float difference;

    private float speed = 0.9f;

    [SerializeField] private TransitNextSceneScript transitNextSceneScript;

    // Start is called before the first frame update
    private void Start()
    {
        positionY = this.transform.position.y; //y軸のポジションを取得
    }

    // Update is called once per frame
    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(speed < 0.0f)
        {
            transitNextSceneScript.TransitNextScene(SCENE_NAME);
            return;
        }

        if(elapsedTime < START_ANIMATION_TIME)
        {
            //Debug.Log("");
        }
        else if(elapsedTime < START_ANIMATION_TIME + ANIMATION_TIME)
        {
            difference = positionY - this.transform.position.y;
            this.transform.position += new Vector3(0.0f, difference, speed);
            speed -= 0.03f;
        }
    }
}
