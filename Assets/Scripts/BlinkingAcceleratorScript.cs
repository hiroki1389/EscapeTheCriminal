using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Rai.
// attached to all Accelerator objects.
public class BlinkingAcceleratorScript : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] private GameObject targetObject;  // 切り替える対象のオブジェクト
    [SerializeField] private GameObject targetObject2;  // 切り替える対象のオブジェクト

    private const float ACTIVATION_DISTANCE = 500.0f;  // アクティブ化する距離

    private int count = 0;
    private const int FREQUENCY = 30;
    private bool isTargetActive = true;  // 切り替える対象の初期アクティブ状態

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.Find("Car_root").transform;

        targetObject.SetActive(false);
        targetObject2.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // ターゲットとの距離を計算
        float distanceToTarget = Vector3.Distance(transform.position, playerTransform.position);

        // ターゲットが一定距離以内にある場合、アクティブ状態を切り替える
        if (distanceToTarget <= ACTIVATION_DISTANCE)
        {
            count++;

            if(count%FREQUENCY == 0)
            {
                targetObject.SetActive(isTargetActive);
                targetObject2.SetActive(!isTargetActive);
                isTargetActive = !isTargetActive;
            }
        }
        else
        {
            targetObject.SetActive(false);
            targetObject2.SetActive(false);
        }
    }
}
