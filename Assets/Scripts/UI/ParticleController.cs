using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Yamada.
// attached to ParticleSystem object.
public class ParticleController : MonoBehaviour
{
    [SerializeField] private GameObject particleSystem;
    private ParticleSystem particlecolor;
    private Rigidbody playerRigidbody;

    private void Start()
    {
        particlecolor = particleSystem.GetComponent<ParticleSystem>();
        playerRigidbody = GameObject.Find("Car_root").GetComponent<Rigidbody>();
        
        particleSystem.gameObject.SetActive(false);
    }

    private void Update()
    {
        float speed = playerRigidbody.velocity.x;

        if(speed < 50.0f) particleSystem.gameObject.SetActive(false);
        else if(speed <= 200.0f)
        {
            particleSystem.gameObject.SetActive(true);
            var alpha = speed + 50.0f;
            var newColor = new Color32((byte)255, (byte)255, (byte)255, (byte)alpha);
            particlecolor.startColor = newColor;
        }
    }

}
