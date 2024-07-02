using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Tsutae.
// attached to ???.
public class ETMoveController : MonoBehaviour
{
    //スタートと終わりの目印
    [SerializeField] private Transform startMarker;
    [SerializeField] private Transform endMarker;

    // スピード
    [SerializeField] private float speed = 5.0f;

    //二点間の距離を入れる
    private float distance_two;
    
    private float elapsedTime = 0.0f;

    private void Start()
    {
        //二点間の距離を代入(スピード調整に使う)
        distance_two = Vector3.Distance(startMarker.position, endMarker.position);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // 現在の位置
        float present_Location = (elapsedTime * speed) / distance_two;

        // オブジェクトの移動
        transform.position = Vector3.Slerp(startMarker.position, endMarker.position, present_Location);// 曲線
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, present_Location);// 直線

    }
}
