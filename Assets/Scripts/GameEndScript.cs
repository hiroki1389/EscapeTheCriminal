using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// created by Hiroki.
// absorbed part of TimeLimitController written by Tsutae.
// attached to Goal object in MainScene.
public class GameEndScript : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject policeCar;

    private const float START_TIME = -5.0f;
    private float elapsedTime;

    [SerializeField] private GameObject timeUpPanel; // ゲームオーバーパネルに変更？
    [SerializeField] private Text instructionText;

    private int gameOverCount = 0;
    private const int ANIMATION_TIME = 120;
    private const float BLOWING_DISTANCE = 30.0f;
    private const float ROTATION_ANGLE = 1080.0f;

    private bool gameClearFlag = false;
    private bool gameOverFlag = false;

    [SerializeField] private TransitNextSceneScript transitNextSceneScript;
    private AEGameSpeedScript aEGameSpeedScript;

    private string GOOD_END_SCENE_NAME = "GoodEndScene";
    private string BAD_END_SCENE_NAME = "GameOverScene";

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root"); // Player object name
        aEGameSpeedScript = player.GetComponent<AEGameSpeedScript>();

        elapsedTime = START_TIME;

        timeUpPanel.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

        elapsedTime += Time.deltaTime * Time.timeScale;

        if (elapsedTime < 0.0f) return;

        if (!gameOverFlag && player.transform.position.x < policeCar.transform.position.x + 10.0f)
        {
            gameOverFlag = true;
            aEGameSpeedScript.SetSpeed(1.0f);

            instructionText.text = "";
            timeUpPanel.SetActive(true);
        }

        if (gameOverFlag)
        {
            gameOverCount++;

            //player.transform.position += new Vector3(BLOWING_DISTANCE, 0.0f, 0.0f) / ANIMATION_TIME;
            //player.transform.Rotate(new Vector3(0.0f, ROTATION_ANGLE, 0.0f) / ANIMATION_TIME);

            if (gameOverCount == ANIMATION_TIME) transitNextSceneScript.TransitNextScene(BAD_END_SCENE_NAME);
        }

        if (!gameClearFlag && this.transform.position.x < player.transform.position.x)
        {
            gameClearFlag = true;

            ScoreMemoryScript.InsertScore(elapsedTime);
            ScoreMemoryScript.SaveScores();

            transitNextSceneScript.TransitNextScene(GOOD_END_SCENE_NAME);
        }
    }
}