using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandler : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] Vector3 rotateDirection= Vector3.forward;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateDirection, rotateSpeed * Time.deltaTime);
    }
}
