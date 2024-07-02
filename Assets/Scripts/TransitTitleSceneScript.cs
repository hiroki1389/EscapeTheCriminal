using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to BlackImage object in GameOverScene and ScoreScene.
public class TransitTitleSceneScript : MonoBehaviour
{
    [SerializeField] private string SCENE_NAME = "TitleScene";

    [SerializeField] private TransitNextSceneScript transitNextSceneScript;

    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update()
    {
        // スペースキーを押したら遷移
        if (Input.GetKeyDown(KeyCode.Space)) transitNextSceneScript.TransitNextScene(SCENE_NAME);
    }
}
