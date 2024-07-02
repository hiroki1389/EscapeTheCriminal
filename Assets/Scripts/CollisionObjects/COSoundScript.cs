using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// created by Hiroki.
// attached to all collision objects.
public class COSoundScript : MonoBehaviour
{
    [SerializeField] private AudioClip se;

    // Start is called before the first frame update
    private void Start() { }

    // Update is called once per frame
    private void Update() { }

    // be called once in collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") AudioSource.PlayClipAtPoint(se, transform.position);
    }
}
