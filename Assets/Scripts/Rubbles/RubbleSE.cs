using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Takanaga.
// attached to Rubbles object.
public class RubbleSE : MonoBehaviour
{
    private GameObject player;
    
    [SerializeField] private GameObject RubbleAll;
    [SerializeField] private GameObject Rubble1;
    [SerializeField] private GameObject Rubble3;
    [SerializeField] private GameObject Rubble5;
    [SerializeField] private GameObject Rubble7;

    [SerializeField] private GameObject startRubbleSmall;
    [SerializeField] private GameObject startRubbleMedium;
    [SerializeField] private GameObject startRubbleLarge;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Car_root");
        
        RubbleAll.gameObject.SetActive(false);
        Rubble1.gameObject.SetActive(false);
        Rubble3.gameObject.SetActive(false);
        Rubble5.gameObject.SetActive(false);
        Rubble7.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(startRubbleSmall.transform.position.x < player.transform.position.x)
        {
            RubbleAll.gameObject.SetActive(true);
        }
        if(startRubbleMedium.transform.position.x < player.transform.position.x)
        {
            Rubble1.gameObject.SetActive(true);
            Rubble3.gameObject.SetActive(true);
        }
        if(startRubbleLarge.transform.position.x < player.transform.position.x)
        {
            Rubble5.gameObject.SetActive(true);
            Rubble7.gameObject.SetActive(true);
        }
    }
}
