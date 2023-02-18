using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAroundObject : MonoBehaviour
{
    [SerializeField] GameObject[] listSpawnObject;
    [SerializeField] float radius = 10;
    [SerializeField] float rotationSpeed = 10f;
    private List<Vector3> spawnPosition = new List<Vector3>();
    private bool isSpawnComplete = false;
    
    // Start is called before the first frame update
    void Start()
    {        
        CalculateSpawnPosition();
        BeginSpawnObject();
        isSpawnComplete = true;
    }

    private void Update()
    {        
        Debug.Log(transform.position);
        
    }

    private void BeginSpawnObject()
    {
        for(int i = 0; i< listSpawnObject.Length; i++)
        {
            listSpawnObject[i].transform.position = spawnPosition[i];
            listSpawnObject[i].GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void CalculateSpawnPosition()
    {
        for(int i = 0; i< listSpawnObject.Length; i++)
        {
            float angle = i * Mathf.PI * 2 / listSpawnObject.Length;
            float xPosition = Mathf.Cos(angle) * radius;
            float yPosition = Mathf.Sin(angle) * radius;
            spawnPosition.Add(new Vector3(xPosition, yPosition, 0));            
        }
    }
}
