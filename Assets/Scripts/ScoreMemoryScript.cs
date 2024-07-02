using UnityEngine;
using System.Linq;

// created by Hiroki.
// This is a static script, so no need to attach anything.
public static class ScoreMemoryScript
{
    private static float[] scores = Enumerable.Repeat((float)5999.99, 10).ToArray();
    private static float latestScore = 5999.99f;
    private static bool dataLoadedFlag = false;

    // 最新スコアとランキングを更新（クリア確定時に呼び出す）
    public static void InsertScore(float value)
    {
        // 最新スコアを更新
        latestScore = value;

        // ランキング外なら何もしない
        if (value >= scores[scores.Length - 1]) return;

        // 最新スコアを入れて挿入ソート
        for (int i = scores.Length - 2; i > -1; i--)
        {
            if (value < scores[i])
            {
                scores[i+1] = scores[i];
            }
            else
            {
                scores[i+1] = value;
                return;
            }
        }
        scores[0] = value;
    }

    // 保存されている変数の値を読み込む（TitleSceneを再生開始時に呼び出す）
    public static void LoadScores()
    {
        if (dataLoadedFlag) return;

        dataLoadedFlag = true;

        // score配列を読み込み
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = PlayerPrefs.GetFloat("score_" + i, 5999.99f);
        }

        Debug.Log("load");
    }

    // 現在の変数の値を保存する（GoodEndSceneに遷移する直前に呼び出す）
    public static void SaveScores()
    {
        if (!dataLoadedFlag) return;

        // score配列を保存
        for (int i = 0; i < scores.Length; i++)
        {
            PlayerPrefs.SetFloat("score_" + i, scores[i]);
        }

        // PlayerPrefsに保存
        PlayerPrefs.Save();

        Debug.Log("save");
    }

    // 各スコアを返す，0は最新スコア，1以降はランキング順のスコア（ScoreSceneで呼び出す）
    public static float ReturnScore(int num)
    {
        if (num == 0) return latestScore;
        else if (0 < num && num < 11) return scores[num-1];
        else return -1.0f;
    }
}