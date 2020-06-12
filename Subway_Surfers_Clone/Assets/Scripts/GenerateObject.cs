using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GenerateObject : MonoBehaviour
{
    // Variables
    [SerializeField] private List<GameObject> objectList; // List that stores objects, e.g., coins, powerups.

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, objectList.Count); // Generate random index to pick up object from list to spawn.
        GameObject instance = Instantiate(objectList[index], transform.position, Quaternion.identity); // Spawn object at position of game object, which has this script attached to.
        instance.transform.parent = transform; // Make spawned object a child of spawn point. That way spawned objects will be destroyed along with spawn point, when destroying a chunk.
    }
}
