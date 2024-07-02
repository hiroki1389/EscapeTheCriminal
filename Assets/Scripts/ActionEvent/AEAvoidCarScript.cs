using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to Start object of the car fire event in MainScene.
public class AEAvoidCarScript : MonoBehaviour
{
    private GameObject player;
    private AEGameSpeedScript aEGameSpeedScript;

    private int eventFlag = 0;

    [SerializeField] private GameObject end;

    [SerializeField] private Text instructionText;

    private float SLOW_RATE = 0.2f;

    [SerializeField] private bool rightFlag = true;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        aEGameSpeedScript = player.GetComponent<AEGameSpeedScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (eventFlag == 0 && this.transform.position.x < player.transform.position.x)
        {
            eventFlag++;

            if(rightFlag) instructionText.text = "⇨\n右に避けろ！！！";
            else instructionText.text = "⇦\n左に避けろ！！！";

            aEGameSpeedScript.SetSpeed(SLOW_RATE);
        }

        if (eventFlag == 1 && end.transform.position.x < player.transform.position.x)
        {
            eventFlag++;
            
            instructionText.text = "";
            
            aEGameSpeedScript.SetSpeed(1.0f);

            return;
        }
    }
}