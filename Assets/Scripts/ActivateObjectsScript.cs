using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to parents of objects which are high load.
public class ActivateObjectsScript : MonoBehaviour
{
    [SerializeField] private float ACTIVATION_DISTANCE = 500.0f; // オブジェクトを有効にする距離

    private GameObject[] childObjects; // 子オブジェクトの配列
    private Transform playerTransform;

    private void Start()
    {
        // 子オブジェクトの配列を取得
        childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            childObjects[i].SetActive(false); // 最初にすべて非アクティブにする
        }

        playerTransform = GameObject.Find("Car_root").transform;
    }

    private void Update()
    {
        // プレイヤーの位置を取得
        Vector3 playerPosition = playerTransform.position;

        // 各子オブジェクトの位置とプレイヤーとの距離を計算して、距離が一定範囲内ならオブジェクトを有効にする
        foreach (GameObject child in childObjects)
        {
            float distance = Vector3.Distance(child.transform.position, playerPosition);

            if (distance < ACTIVATION_DISTANCE) child.SetActive(true);
            else child.SetActive(false);
        }
    }
}