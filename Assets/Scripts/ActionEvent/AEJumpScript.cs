using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// created by Hiroki.
// attached to Start object of the jump action event in MainScene.
public class AEJumpScript : MonoBehaviour
{
    [SerializeField] private AudioClip se;
    
    private float SLOW_RATE = 0.2f;
    private bool eventFlag = true;
    private int accerlerateFlag = 0;

    private const int ACCELERATE_TIME = 100;
    private const int ROTATION = 400;

    private float distanceX;
    private float distanceZ;
    private const float HEIGHT = 20.0f;

    private Vector3 vector;

    private GameObject player;
    private AEGameSpeedScript aEGameSpeedScript;
    [SerializeField] private GameObject end;

    [SerializeField] private Canvas canvases;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        aEGameSpeedScript = player.GetComponent<AEGameSpeedScript>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(0 < accerlerateFlag  && accerlerateFlag <= 151)
        {
            if(accerlerateFlag <= ACCELERATE_TIME)
            {
                player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                player.transform.Rotate(new Vector3(0.0f, 0.0f, ROTATION/ACCELERATE_TIME));
                if(accerlerateFlag <= ACCELERATE_TIME/2)
                {
                    player.transform.position = player.transform.position + new Vector3(distanceX, HEIGHT, distanceZ)/ACCELERATE_TIME;
                }
                else
                {
                    player.transform.position = player.transform.position + new Vector3(distanceX, -HEIGHT, distanceZ)/ACCELERATE_TIME;
                }
                
                if(accerlerateFlag == ACCELERATE_TIME) 
                {
                    player.GetComponent<Rigidbody>().velocity = vector;
                    canvases.enabled = true;
                }
            }
            else
            {
                if(accerlerateFlag <= 120)
                {
                    player.transform.Rotate(new Vector3(0.0f, 0.0f, -ROTATION)/ACCELERATE_TIME);
                }
                else if(accerlerateFlag <= 135)
                {
                    player.transform.Rotate(new Vector3(0.0f, 0.0f, ROTATION)/ACCELERATE_TIME);
                }
                else if(accerlerateFlag <= 145)
                {
                    player.transform.Rotate(new Vector3(0.0f, 0.0f, -ROTATION)/ACCELERATE_TIME);
                }
                else if(accerlerateFlag <= 150)
                {
                    player.transform.Rotate(new Vector3(0.0f, 0.0f, ROTATION)/ACCELERATE_TIME);
                }
                else if(accerlerateFlag == 151)
                {
                    player.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));
                }
            }
            accerlerateFlag++;
        }

        if (end.transform.position.x < player.transform.position.x)
        {
            if(!eventFlag)
            {
                eventFlag = true;
                aEGameSpeedScript.SetSpeed(1.0f);
            }
        }
        else if (this.transform.position.x < player.transform.position.x)
        {
            if(eventFlag)
            {
                AudioSource.PlayClipAtPoint(se, transform.position);

                eventFlag = false;
                aEGameSpeedScript.SetSpeed(SLOW_RATE);

                distanceX = end.transform.position.x - player.transform.position.x;
                distanceZ = end.transform.position.z - player.transform.position.z;
                vector = player.GetComponent<Rigidbody>().velocity;
                accerlerateFlag++;
                
                canvases.enabled = false;
            }
        }
    }
}
