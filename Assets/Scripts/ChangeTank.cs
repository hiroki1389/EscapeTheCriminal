using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTank : MonoBehaviour
{
    private GameObject player;
    public GameObject BreakTank;
    public GameObject Tank;
    public GameObject StartCube;
    public GameObject puddlea;
    public GameObject puddleb;
    public ParticleSystem FlareParticle;
    public ParticleSystem WaterParticle;
    //public ParticleSystem PuddleParticle1;
    //public ParticleSystem PuddleParticle2;
    //public ParticleSystem PuddleParticle3;
    //public ParticleSystem PuddleParticle4;
    private Vector3 WaterFlow;
    private Vector3 puddle1;
    private Vector3 puddle2;
    private Vector3 puddle3;
    private Vector3 puddle4;
    private bool check;
    public float scale = 0.5f;
    private float rx = 90.0f;
    private int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Car_root");
        WaterFlow = new Vector3(Tank.transform.position.x + (float)0.26 * scale, Tank.transform.position.y + 1.50f * scale, Tank.transform.position.z - 1.87f * scale);
        puddle1 = new Vector3(Tank.transform.position.x - 1.18f * scale, Tank.transform.position.y-2.5f * scale, Tank.transform.position.z - 10.7f * scale);
        puddle2 = new Vector3(Tank.transform.position.x - 0.10f * scale, Tank.transform.position.y-2.5f * scale, Tank.transform.position.z - 7.15f * scale);
        puddle3 = new Vector3(Tank.transform.position.x - 4.28f * scale, Tank.transform.position.y-2.5f * scale, Tank.transform.position.z - 10.7f * scale);
        puddle4 = new Vector3(Tank.transform.position.x - 4.18f * scale, Tank.transform.position.y-2.5f * scale, Tank.transform.position.z - 7.15f * scale);
        check = true;
        FlareParticle.gameObject.SetActive(false);
        puddlea.gameObject.SetActive(false);
        puddleb.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
            if(StartCube.transform.position.x < player.transform.position.x && flag == 0)
            {
            check = true;
            flag = 1;
            }

            if (check == true)
            {
                //FlareParticle.gameObject.SetActive(true);
                Invoke("ChangeBreak", 1.0f);
                check = false;
            
            }
    }

    void ChangeBreak()
    {
        BreakTank = Instantiate(BreakTank, Tank.transform.position, Quaternion.Euler(0f, -90f, 0f));
        BreakTank.transform.localScale = new Vector3(scale, scale, scale);
        WaterParticle = Instantiate(WaterParticle, WaterFlow, Quaternion.Euler(21.7f, -270f, 75.5f));
        WaterParticle.transform.localScale = new Vector3(scale, scale, scale);
        puddlea.gameObject.SetActive(true);
        puddleb.gameObject.SetActive(true);
        /*
        PuddleParticle1 = Instantiate(PuddleParticle1, puddle1, Quaternion.identity);
        PuddleParticle1.transform.localScale = new Vector3(scale, scale, scale);
        PuddleParticle2 = Instantiate(PuddleParticle2, puddle2, Quaternion.identity);
        PuddleParticle2.transform.localScale = new Vector3(scale, scale, scale);
        PuddleParticle3 = Instantiate(PuddleParticle3, puddle3, Quaternion.identity);
        PuddleParticle3.transform.localScale = new Vector3(scale, scale, scale);
        PuddleParticle4 = Instantiate(PuddleParticle4, puddle4, Quaternion.identity);
        PuddleParticle4.transform.localScale = new Vector3(scale, scale, scale);
        */
        Tank.SetActive(false);
        Destroy(FlareParticle);
        
    }
    
}
