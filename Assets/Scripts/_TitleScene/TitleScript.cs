using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to BlackImage object in TitleScene.
public class TitleScript : MonoBehaviour
{
    private const string SCENE_NAME = "OpeningScene";
    
    [SerializeField] private TransitNextSceneScript transitNextSceneScript;

    // Start is called before the first frame update
    private void Start() 
    {
        ScoreMemoryScript.LoadScores();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) transitNextSceneScript.TransitNextScene(SCENE_NAME);
    }
}