using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to all parents of Obstacle object.
public class RelocationAndResizeObjectsScript : MonoBehaviour
{
    private GameObject[] childObjects; // 子オブジェクトの配列

    [SerializeField] private bool phase2Flag = false;

    private float randZ = 0.0f;
    private const float SMALL_SCALE = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
        // 子オブジェクトの配列を取得
        childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            
            // ランダムな位置に配置
            if(phase2Flag) randZ = Random.Range(8.0f, 20.0f); // ジャンプ後のほう
            else randZ = Random.Range(-6.0f, 6.0f); // ジャンプ前のほう
            childObjects[i].transform.position = new Vector3(childObjects[i].transform.position.x, childObjects[i].transform.position.y, randZ);
            
            // 大きさを小さくする
            childObjects[i].transform.localScale *= SMALL_SCALE;
        }
    }
}
