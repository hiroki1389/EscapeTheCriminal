using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Rai.
// attached to BoatSet object in GoodEndScene.
public class GEBoatScript : MonoBehaviour
{
    private float elapsedTime = 0.0f;
    private const float START_ANIMATION_TIME = 7.0f;
    private const float ANIMATION_TIME_1 = 2.5f;
    private const float ANIMATION_TIME_2 = 12.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition = new Vector3(12400f, 2.24f, -210.7f); //到着地点をセット

    //ボートをz方向に少し動かす変数
    private float z = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        //スタート位置をキャッシュ
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime < START_ANIMATION_TIME)
        {
            //Debug.Log("");

        }
        else if(elapsedTime < START_ANIMATION_TIME + ANIMATION_TIME_1)
        {
            //現在フレームの補間値を計算
            float interpolatedValue = (elapsedTime - START_ANIMATION_TIME) / 2.5f;
            //移動させる
            transform.position = Vector3.Lerp(startPosition, targetPosition, interpolatedValue);

        }
        else if(elapsedTime < START_ANIMATION_TIME + ANIMATION_TIME_1 + ANIMATION_TIME_2)
        {
            this.transform.position += new Vector3(0.8f, 0.0f, 0.0f);
        }
    }
}
