using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// created by Tsutae.
// attached to Canvas object in TitleScene.
public class TitleTextMoving : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Text messageText;
    private string[] wordArray;
    private string words;

    [SerializeField] private float SPEED = 1.0f;

    //private
    private Image image;
    private float time;

    // Start is called before the first frame update
    private void Start()
    {
        //words = "逃,げ,き,れ,！,\n,　,　,　,疾,走,犯,！";
        words = "疾,走,犯,！";

        wordArray = words.Split(',');
        StartCoroutine("SetText");
    }

    // Update is called once per frame
    private void Update()
    {
        messageText.color = GetAlphaColor(messageText.color);
    }

    IEnumerator SetText()
    {
        yield return new WaitForSeconds(0.3f);

        foreach (var p in wordArray)
        {
            text.text = text.text + p;
            yield return new WaitForSeconds(0.1f);
        }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * SPEED;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
