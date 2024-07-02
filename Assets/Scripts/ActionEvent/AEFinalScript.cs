using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to Start object of the final action event in MainScene.
public class AEFinalScript : MonoBehaviour
{
    private bool rockEventFlag = false;
    private bool rifleEventFlag = false;
    private bool slowEventFlag = false;

    private GameObject player;
    private Rigidbody rigidbody;
    private AEGameSpeedScript aEGameSpeedScript;

    [SerializeField] private GameObject startRock;
    [SerializeField] private GameObject startRifle;
    [SerializeField] private GameObject startFinalSlow;
    [SerializeField] private GameObject endFinalSlow;

    [SerializeField] private GameObject rock;

    [SerializeField] private GameObject moveRifleman1;
    [SerializeField] private GameObject moveRifleman2;
    [SerializeField] private GameObject dummyRiflemanParent;

    [SerializeField] private GameObject movePoliceCar1;
    [SerializeField] private GameObject movePoliceCar2;
    [SerializeField] private GameObject dummyPoliceCarParent;

    [SerializeField] private GameObject uICanvases1;
    [SerializeField] private GameObject uICanvases2;

    [SerializeField] private Text instructionText;
    private float SLOW_RATE = 0.3f;

    private const float INIT_SPEED = 200.0f;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        aEGameSpeedScript = player.GetComponent<AEGameSpeedScript>();
        rigidbody = player.GetComponent<Rigidbody>();
        
        rock.gameObject.SetActive(false);
        moveRifleman1.gameObject.SetActive(false);
        moveRifleman2.gameObject.SetActive(false);
        movePoliceCar1.gameObject.SetActive(false);
        movePoliceCar2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!rockEventFlag && startRock.transform.position.x < player.transform.position.x)
        {
            rockEventFlag = true;

            rock.gameObject.SetActive(true);

            uICanvases1.gameObject.SetActive(false);
            uICanvases1.gameObject.SetActive(false);

            rigidbody.velocity += new Vector3(-rigidbody.velocity.x + INIT_SPEED, 0.0f, 0.0f);
        }

        if (!rifleEventFlag && startRifle.transform.position.x < player.transform.position.x)
        {
            rifleEventFlag = true;

            moveRifleman1.gameObject.SetActive(true);
            moveRifleman2.gameObject.SetActive(true);
            dummyRiflemanParent.gameObject.SetActive(false);

            movePoliceCar1.gameObject.SetActive(true);
            movePoliceCar2.gameObject.SetActive(true);
            dummyPoliceCarParent.gameObject.SetActive(false);
        }

        if (!slowEventFlag && startFinalSlow.transform.position.x < player.transform.position.x)
        {
            slowEventFlag = true;

            aEGameSpeedScript.SetSpeed(SLOW_RATE);
            instructionText.text = "瓦礫の下に突っ込め！！！";

        }

        if (endFinalSlow.transform.position.x < player.transform.position.x)
        {
            aEGameSpeedScript.SetSpeed(1.0f);
            instructionText.text = "";

            return;
        }
    }
}
