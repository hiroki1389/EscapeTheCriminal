using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    int check = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(11);
        if(other.gameObject.tag == "Spin" && check == 1)
        {
            transform.DORotate(new Vector3(360, 0, 0), 1);
            check = 0;
        }
    }*/

   /* private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Spin")
        {
            transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360);
            Debug.Log("11");
        }
    }*/

    private void OnParticleCollision(GameObject other)
    {
        if (gameObject.CompareTag("Water") && check == 1)
        {
            transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360);
            check = 0;
            Debug.Log(check);
        }
    }

}
;