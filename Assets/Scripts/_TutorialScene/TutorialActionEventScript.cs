using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to ActionObstacle object in TutorialScene.
public class TutorialActionEventScript : MonoBehaviour
{
    private GameObject player;
    private AEGameSpeedScript aEGameSpeedScript;

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;

    private bool eventFlag = false;

    [SerializeField] private Text instructionText;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        aEGameSpeedScript = player.GetComponent<AEGameSpeedScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (end.transform.position.x < player.transform.position.x)
        {
            if(eventFlag)
            {
                eventFlag = false;
                aEGameSpeedScript.SetSpeed(1.0f);
                instructionText.text = "";
            }
        }
        else if (start.transform.position.x < player.transform.position.x)
        {
            if(!eventFlag)
            {
                eventFlag = true;
                aEGameSpeedScript.SetSpeed(0.2f);
                instructionText.text = "避けろ！！";
            }
        }
    }
}