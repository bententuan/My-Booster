using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = Vector3.zero;
    [SerializeField] float periods = 1;
    Vector3 startingPoint= Vector3.zero;
    private float movementFactor = 1;

    private void Start()
    {
        startingPoint= transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / periods;
        const float tau = Mathf.PI;
        float rawSin = Mathf.Sin(cycles * tau);
        movementFactor = (rawSin + 1f) / 2f;        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
