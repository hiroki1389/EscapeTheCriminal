using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// created by Yamada.
// edited by Yamda and Hiroki. 
// attached to Start object of the car fire event in MainScene.
public class AECarFireScript : MonoBehaviour
{
    private GameObject player;
    public bool waterflag = false;
    public float wspeed = 1.0f;

    [SerializeField] private GameObject tunnel;
    [SerializeField] private GameObject tunnelBreak;

    [SerializeField] private GameObject policeCar;

    private bool eventFlag = false;
    
    private const float INIT_SPEED = 1.0f;
    private float speed = 0.0f;
    
    private Transform policeCarTransform;

    [SerializeField] private bool rightFlag = true;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        
        tunnelBreak.gameObject.SetActive(false);
        policeCar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(!eventFlag && player.transform.position.x > this.transform.position.x)
        {
            eventFlag = true;
            
            tunnel.gameObject.SetActive(false);
            tunnelBreak.gameObject.SetActive(true);
            policeCar.gameObject.SetActive(true);

            speed = INIT_SPEED;
            policeCarTransform = policeCar.transform;
        }
        else if (eventFlag && speed > 0) 
        {
            Vector3 policeCarPosition = policeCarTransform.position;
            if(!waterflag){
                if(rightFlag) policeCarPosition.z -= speed;
                else policeCarPosition.z += speed;
            }else{
                policeCarPosition.z += wspeed;
            }


            policeCarTransform.position = policeCarPosition;
            speed *= 0.9f;
            wspeed *= 0.9f;
        }
    }
}
