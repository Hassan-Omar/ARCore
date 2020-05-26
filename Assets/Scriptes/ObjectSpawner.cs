﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    
    public GameObject[] objectsToSpawn;
   [SerializeField] private GameObject placementIndicator;
    public GameObject LastCreatedObject; 
    private void Start()
    {
        //placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    /*private void Update()
    {
        if(Input.touchCount >0 && Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject obj = Instantiate(objectToSpawn);
            obj.transform.position = placementIndicator.transform.position;
            obj.name = "7777";
        }
    }*/

    /// <summary>
    /// Function to Creates Obj Based on Selected Id 
    /// </summary>
    /// <param name="id">The index of Object I wanna to spawn </param>
    public void spawnObjectById(int id)
    {
        LastCreatedObject = Instantiate(objectsToSpawn[id]);
        LastCreatedObject.transform.position = placementIndicator.transform.position;
    }
}
