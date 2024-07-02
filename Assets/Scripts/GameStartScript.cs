using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// created by Hiroki.
// edited by Hiroki and Yamada.
// attached to Start object in MainScene.
public class GameStartScript : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Image imageComponent1;
    [SerializeField] private Image imageComponent2;
    [SerializeField] private Image imageComponent3;

    [SerializeField] private GameObject lightSignalImage; 

    private const float START_TIME = 5.0f;
    private float startTime;

    [SerializeField] private Text instructionText;

    private bool startEndFlag = false;
    private bool countDownFlag = false;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root"); // Player object name

        imageComponent1.color = new Color32(155, 155, 155, 255);
        imageComponent2.color = new Color32(155, 155, 155, 255);
        imageComponent3.color = new Color32(155, 155, 155, 255);

        startTime = START_TIME;
        
        instructionText.text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        if (!startEndFlag)
        {
            startTime -= Time.deltaTime;
            if(startTime > 0.0f)
            {
                if ((int)startTime == 0)
                {
                    imageComponent1.color = new Color32(0, 255, 128, 255);
                    imageComponent2.color = new Color32(0, 255, 128, 255);
                    imageComponent3.color = new Color32(0, 255, 128, 255);
                    instructionText.text = "S T A R T ! ! ! ! !";
                }
                else
                {
                    player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                    if ((int)startTime == 3)
                    {
                        if(!countDownFlag)
                        {
                            countDownFlag = !countDownFlag;
                            audioSource.Play();
                            imageComponent1.color = new Color32(255, 0, 0, 255);
                        }
                    }
                    if ((int)startTime == 2) imageComponent2.color = new Color32(255, 0, 0, 255);
                    if ((int)startTime == 1) imageComponent3.color = new Color32(255, 0, 0, 255);
                }
                return;
            }
            else
            {
                lightSignalImage.SetActive(false);
                instructionText.text = "";
                startEndFlag = true;
            }
        }
    }
}