﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GenerateObject : MonoBehaviour
{
    // Variables
    [SerializeField] private List<GameObject> objectList; // List that stores objects, e.g., coins, powerups.
    [SerializeField] private int objectIndex; // Used to pick up object from list.
    // Object chances to spawn
    [Header("Chances are defined by difference of numbers below.")]
    [SerializeField] private int Empty = 50;
    [SerializeField] private int Coin = 85;
    [SerializeField] private int Wall = 100;
    private int previousRangeMax; // Used to store max value of previous range check

    // Start is called before the first frame update
    void Start()
    {
        // Object Generation routine 
        int rand = Random.Range(0, 100); // Generate random number to decide, which object to spawn.
        // Define chances of objects to be spawned 
        // Empty space
        if(rand >= 0 && rand < Empty)
        {
            objectIndex = 0;
            previousRangeMax = Empty;
        }
        // Coin
        if (rand >= previousRangeMax && rand < Coin)
        {
            objectIndex = 1;
            previousRangeMax = Coin;
        }
        // Wall
        if (rand >= previousRangeMax && rand < Wall)
        {
            // if amount of obstacles present on chunk do not exceed the allowed amount, spawn a new one.
            if (FindObjectOfType<Chunk>().GetObstacleAmount() < FindObjectOfType<Chunk>().GetAllowedObstacleAmount())
            {
                objectIndex = 2;
                previousRangeMax = Wall;
                FindObjectOfType<Chunk>().ChangeObstacleAmount(1);
            }
        }
        GameObject instance = Instantiate(objectList[objectIndex], transform.position, Quaternion.identity); // Spawn object at position of game object, which has this script attached to.
        instance.transform.position = new Vector3(transform.position.x, objectList[objectIndex].transform.position.y, transform.position.z); // Change y coordinate of spawned object
        instance.transform.parent = transform; // Make spawned object a child of spawn point. That way spawned objects will be destroyed along with spawn point, when destroying a chunk.
    }
}
