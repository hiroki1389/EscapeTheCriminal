using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// created by Tsutae.
// attached to SpeedMeterCanvas.
public class SpeedMeterUI : MonoBehaviour
{
    private int count = 0;
    private const int FREQUENCY = 30; // 何フレームに一度速度表示を更新するか

    private Rigidbody playerRigidbody;

    // 速度計のゲージイメージ
    [SerializeField] private Image meterObject;
    [SerializeField] private Text speedText;

    // 速度変数
    private float nowVelocity;
    private const float MIN_VELOCITY = 0.0f;
    [SerializeField] private float MAX_VELOCITY = 180.0f;

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GameObject.Find("Car_root").GetComponent<Rigidbody>();

        meterObject = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        nowVelocity = playerRigidbody.velocity.x;

        // メータを速度によって塗る
        meterObject.fillAmount = ((nowVelocity / MAX_VELOCITY) * 0.8f) + 0.1f;

        // 数フレームに一回だけメータの値を更新する
        if (count % FREQUENCY == 0) speedText.text = nowVelocity.ToString("0") + " km/h";

        count++;
    }
}
