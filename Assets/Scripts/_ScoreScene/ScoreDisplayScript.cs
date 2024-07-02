using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// created by Hiroki.
// attached to Canvas object in ScoreScene.
public class ScoreDisplayScript : MonoBehaviour
{
    [SerializeField] private int NUMBER_OF_RANKINGS = 5; // 表示したいランキング数

    private Text[] scoreTexts; // 取得したスコアを格納する配列，0番目が最新スコアで，1番目以降はランキング順

    private const string LATEST_SCORE_TEXT_NAME = "LatestScoreText"; // 最新スコアを表示するテキストオブジェクト名
    private const string RANKING_TEXT_NAME_FORMAT = "RankingText{0}"; // ランキングを表示する各テキストオブジェクト名のフォーマット

    // Start is called before the first frame update
    private void Start()
    {
        scoreTexts = new Text[NUMBER_OF_RANKINGS + 1];

        scoreTexts[0] = GameObject.Find(LATEST_SCORE_TEXT_NAME).GetComponent<Text>();
        scoreTexts[0].text = CreateResultText(0);

        for (int i = 1; i < scoreTexts.Length; i++)
        {
            scoreTexts[i] = GameObject.Find(string.Format(RANKING_TEXT_NAME_FORMAT, i)).GetComponent<Text>();
            scoreTexts[i].text = CreateResultText(i);
        }
    }

    // テキストに表示する文字列を生成
    private string CreateResultText(int rank)
    {
        string resultText;

        // rankの値によって表示を変える
        if (rank == 0) resultText = "Your Clear Time: ";
        else if (rank % 10 == 1) resultText = rank + "st Time: ";
        else if (rank % 10 == 2) resultText = rank + "nd Time: ";
        else if (rank % 10 == 3) resultText = rank + "rd Time: ";
        else resultText = rank + "th Time: ";

        // ScoreMemoryScriptからfloat秒を取得してresultTextに追加
        float secondTime = ScoreMemoryScript.ReturnScore(rank);
        resultText += FormatTime(secondTime);

        return resultText;
    }

    // float秒で表されたスコアを何分何秒の文字列にして返す
    private string FormatTime(float secondTime)
    {
        int minuteTime = (int)(secondTime / 60);
        secondTime %= 60;

        string resultTime = minuteTime.ToString() + "分" + secondTime.ToString("0.00") + "秒";

        return resultTime;
    }
}