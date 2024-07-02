using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to InstructionText object in TutorialScene.
namespace VarjoExample
{
    public class TutorialScript : MonoBehaviour
    {
        private Text instructionText;

        private const int NUMBER_OF_TEXT = 19;
        private static readonly string[] TUTORIAL_TEXT_ARRAY = new string[NUMBER_OF_TEXT]
        {
            "あなたは今、銀行強盗をして警察から逃げている途中です",
            "上手く車を操作して逃げ切りましょう。", // 1
            "まずはアクセルとブレーキについてです。",
            "足元の右側のアクセルを踏んで加速してみましょう。",
            "左側のブレーキを踏んで減速もできるので、適宜使用してもいいです。",
            "また、道路には加速台や様々な障害物があります。",
            "ハンドルを回して進行方向を変えることができます。", // 6
            "まずは、加速台に乗ってみましょう。",
            "",
            "次は、障害物を避けてみましょう。",
            "",
            "最後に、スローアクションについての説明です。", // 11
            "走っている間、突然目の前に障害物が現れることがあります。",
            "瞬発的な操作を求められるので、実際にやってみましょう。",
            "",
            "",
            "", // 16
            "これでチュートリアルは終わりです。",
            "それでは本番です。"
        };

        private float elapsedTime = 0.0f;
        private int tutorialPhase = 0;

        private GameObject player;
        private Rigidbody playerRigidbody;

        [SerializeField] private GameObject accelerater;
        [SerializeField] private GameObject obstacle_parent;
        [SerializeField] private GameObject actionObstacle;
        [SerializeField] private GameObject StartAction;


        private float velocity;
        private const float INIT_SPEED = 0.0f; // per second
        private const float MAX_SPEED_2 = 40.0f;

        private float scaleZActionObstacle;
        private const float SHORTENING_Z_LENGTH = 1.0f;
        private const float CHANGE = 3.0f;
        private float lengthRate = 0.0f;

        private const float FREQUENCY = 2.0f;

        [SerializeField] private TransitNextSceneScript transitNextSceneScript;
        private const string SCENE_NAME = "EnteringTunnelScene";

        // Start is called before the first frame update
        private void Start()
        {
            player = GameObject.Find("Car_root"); // Player object name
            playerRigidbody = player.GetComponent<Rigidbody>();

            instructionText = GetComponent<Text>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            //Debug.Log(tutorialPhase);

            switch (tutorialPhase)
            {
                case 4:
                    if(playerRigidbody.velocity.x > 10.0f)  elapsedTime += Time.deltaTime * Time.timeScale;
                    break;
                case 9:
                    if(accelerater.transform.position.x < player.transform.position.x) elapsedTime += Time.deltaTime * Time.timeScale;
                    if (playerRigidbody.velocity.x > 35.0f) player.GetComponent<SimpleCarController>().MAX_SPEED = MAX_SPEED_2;
                    break;
                case 11:
                    if(obstacle_parent.transform.position.x < player.transform.position.x) elapsedTime += Time.deltaTime * Time.timeScale;
                    break;
                case 16:
                    if(lengthRate < 1.0f)
                    {
                        lengthRate += 0.05f;
                        actionObstacle.transform.localScale  
                            += new Vector3(0.0f, 0.0f, -actionObstacle.transform.localScale .z + SHORTENING_Z_LENGTH + (scaleZActionObstacle - SHORTENING_Z_LENGTH) * lengthRate );
                        actionObstacle.transform.position 
                            += new Vector3(0.0f, 0.0f, CHANGE * 0.05f);
                    }
                    elapsedTime += Time.deltaTime * Time.timeScale;
                    break;
                case 17:
                    if(actionObstacle.transform.position.x < player.transform.position.x) elapsedTime += Time.deltaTime * Time.timeScale;
                    break;
                default:
                    elapsedTime += Time.deltaTime * Time.timeScale;
                    break;
            }

            if (tutorialPhase < 4) playerRigidbody.velocity = new Vector3(INIT_SPEED, 0.0f, 0.0f);

            if (elapsedTime > FREQUENCY * tutorialPhase)
            {
                switch (tutorialPhase)
                {
                    case 8:
                        velocity = playerRigidbody.velocity.x;
                        accelerater.transform.position = player.transform.position + new Vector3(velocity * 3, -player.transform.position.y + accelerater.transform.position.y, 0.0f);
                        break;
                    case 10:
                        velocity = playerRigidbody.velocity.x;
                        obstacle_parent.transform.position = player.transform.position + new Vector3(velocity * 5, -player.transform.position.y + obstacle_parent.transform.position.y, 0.0f);
                        break;
                    case 15:
                        scaleZActionObstacle = actionObstacle.transform.localScale.z;
                        actionObstacle.transform.localScale += new Vector3(0.0f, 0.0f, -scaleZActionObstacle + SHORTENING_Z_LENGTH);
                        float distance = actionObstacle.transform.position.x - StartAction.transform.position.x;
                        actionObstacle.transform.position = player.transform.position + new Vector3(distance, -player.transform.position.y + actionObstacle.transform.position.y, -CHANGE);
                        break;
                    case 19:
                        transitNextSceneScript.TransitNextScene(SCENE_NAME);
                        break;
                }

                if(tutorialPhase < NUMBER_OF_TEXT) instructionText.text = TUTORIAL_TEXT_ARRAY[tutorialPhase];
                
                tutorialPhase++;
            }
        }
    }
}