using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// created by Hiroki.
// attached to LatestScoreText object in ScoreScene.
public class ScoreBlinkingScript : MonoBehaviour
{
    private Text text;
    private float blinkInterval = 0.5f;

    IEnumerator Start()
    {
        text = GetComponent<Text>();

        // 0.5秒毎にテキストを点滅させる
        while (true)
        {
            text.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            text.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
