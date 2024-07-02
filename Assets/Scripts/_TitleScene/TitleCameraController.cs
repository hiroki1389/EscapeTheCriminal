using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Tsutae.
// attached to MainCamera object in TitleScene.
public class TitleCameraController : MonoBehaviour
{
    //スタートと終わりの目印
    [SerializeField] private Transform startMarker;
    [SerializeField] private Transform endMarker;

    //二点間の距離を入れる
    private float distanceTwo;

    private float elapsedTime = 0.0f;

    // スピード
    [SerializeField] private float speed = 5.0f;

    [SerializeField] private GameObject titlePanel;

    private void Start()
    {
        //二点間の距離を代入(スピード調整に使う)
        distanceTwo = Vector3.Distance(startMarker.position, endMarker.position);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // 現在の位置
        float present_Location = (elapsedTime * speed) / distanceTwo;

        // オブジェクトの移動
        transform.position = Vector3.Slerp(startMarker.position, endMarker.position, present_Location); // 曲線
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, present_Location); // 直線

        if(this.transform.position.x >= endMarker.position.x) titlePanel.SetActive(true);
    }
}
