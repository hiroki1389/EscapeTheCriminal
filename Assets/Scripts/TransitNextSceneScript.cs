using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// created by Hiroki.
// attached BlackImage object in all scenes.
public class TransitNextSceneScript : MonoBehaviour
{
    private float FADE_SPEED = 0.1f; // 透明度を変える速度
    private Image fadeImage; // 透明度を変えるImage

    private bool transitFlag = false;
    private float elapsedTime = 0.0f;
    [SerializeField] private float TRANSITION_TIME = 2.0f; // 参照関数あり

    private float currentAlpha = 0.0f; // 現在の透明度
    private const float TARGET_ALPHA = 1.5f; // 目標の透明度

    private string sceneName;

    private void Start()
    {
        FADE_SPEED = 1 / TRANSITION_TIME;
        fadeImage = this.GetComponent<Image>();
        fadeImage.enabled = true; // Imageを有効にする
    }

    private void Update()
    {
        if (transitFlag)
        {
            //Debug.Log("transit now");
            if (elapsedTime < TRANSITION_TIME)
            {
                elapsedTime += Time.deltaTime;
                currentAlpha = Mathf.Lerp(currentAlpha, TARGET_ALPHA, FADE_SPEED * Time.deltaTime); // 現在の透明度を変化させる
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, currentAlpha); // Imageの透明度を設定する
            }
            else
            {
                transitFlag = false;
                //Debug.Log("complete transit");
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void TransitNextScene(string sceneName)
    {
        if(transitFlag) return;

       //Debug.Log("start transit");
        this.sceneName = sceneName;
        transitFlag = true;
    }

    // ETTransisionScriptでこの時間を参照して遷移時間を決めてる
    public float ReturnTransitionTime()
    {
        return TRANSITION_TIME;
    }
}