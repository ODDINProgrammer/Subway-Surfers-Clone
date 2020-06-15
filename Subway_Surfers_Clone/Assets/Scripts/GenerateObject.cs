using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GenerateObject : MonoBehaviour
{
    // Variables
    [SerializeField] private List<GameObject> objectList; // List that stores objects, e.g., coins, powerups.
    [SerializeField] private int objectIndex; // Used to pick up object from list.
    // Object chances to spawn
    [Header("Chances to spawn.")]
    [SerializeField] private int Coin = 0;
    [SerializeField] private int Wall = 0;
    private int previousRangeMax; // Used to store max value of previous range check

    // Start is called before the first frame update
    void Start()
    {
        // Object Generation routine 
        int rand = Random.Range(0, 100); // Generate random number to decide, which object to spawn.
        // Define chances of objects to be spawned 
        // Coin
        if (rand >= 0 && rand <= Coin)
        {
            objectIndex = 1;
        }
        // Wall
        if (gameObject.transform.name == "WallPoint")
        {
            if (rand >= 0 && rand <= Wall)
            {
                objectIndex = 2;
            }
        }
        GameObject instance = Instantiate(objectList[objectIndex], transform.position, Quaternion.identity); // Spawn object at position of game object, which has this script attached to.
        instance.transform.position = new Vector3(transform.position.x, objectList[objectIndex].transform.position.y, transform.position.z); // Change y coordinate of spawned object
        instance.transform.parent = transform; // Make spawned object a child of spawn point. That way spawned objects will be destroyed along with spawn point, when destroying a chunk.
    }
}
