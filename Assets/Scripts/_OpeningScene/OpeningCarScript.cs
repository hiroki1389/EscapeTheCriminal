using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// created by Rai.
// attached to Car object in OpeningScene.
public class OpeningCarScript : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private float START_ANIMATION_TIME = 5.0f;
    private float ANIMATION_TIME_1 = 2.5f;
    private const float ANIMATION_TIME_2 = 8.0f;

    private const string SCENE_NAME = "TutorialScene";

    private float distance;
    private Vector3 startPosition;
    private Vector3 targetPosition = new Vector3(239.812f, 8.18f, -1127.93f);

    [SerializeField] private TransitNextSceneScript transitNextSceneScript;

    // Start is called before the first frame update
    void Start()
    {
        //スタート位置をキャッシュ
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime < START_ANIMATION_TIME)
        {
            Debug.Log("");
        }
        else if(elapsedTime < START_ANIMATION_TIME + ANIMATION_TIME_1)
        {
            //現在フレームの補間値を計算
            float interpolatedValue = (elapsedTime - START_ANIMATION_TIME) / 2.5f;
            //移動させる
            transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);
        }
        else if(elapsedTime + transitNextSceneScript.ReturnTransitionTime() < START_ANIMATION_TIME + ANIMATION_TIME_1 + ANIMATION_TIME_2)
        {
            transitNextSceneScript.TransitNextScene(SCENE_NAME);
        }
    }
}