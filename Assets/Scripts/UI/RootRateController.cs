using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// created by Tsutae.
// attached to RootRateSlider objects.
public class RootRateController : MonoBehaviour
{
    private Slider rootSlider;
    [SerializeField] private GameObject car;

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject goal;

    private float startPos;
    private float distance;

    // Start is called before the first frame update
    private void Start()
    {
        rootSlider = GetComponent<Slider>();

        startPos = start.transform.position.x;
        distance = goal.transform.position.x - startPos;
    }

    // Update is called once per frame
    private void Update()
    {
        float rootRate = (car.transform.position.x - startPos) / distance;

        rootSlider.value = rootRate;
    }
}
