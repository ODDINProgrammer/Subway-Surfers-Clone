using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GenerateObject : MonoBehaviour
{
    // Variables
    private int objectIndex;  // Used to pick up object from list.
    private enum ObtectType
    {
        Coin = 1,
        Wall = 2,
        LampPost = 3
    }
    private SpawnChances _object;

    // Start is called before the first frame update
    void Start()
    {
        _object = FindObjectOfType<SpawnChances>();
        // Object Generation routine 
        // Generate random number to decide, which object to spawn.
        int rand = Random.Range(0, 100); 
        // Define chances of objects to be spawned 
        // Coin
        if (rand > 0 && rand <= _object.getChanceValue((int)ObtectType.Coin))
        {
            objectIndex = 1;
        }
        // Wall
        if (gameObject.transform.name == "WallPoint")
        {
            if (rand > 0 && rand <= _object.getChanceValue((int)ObtectType.Wall))
            {
                objectIndex = 2;
            }
        }
        //Lamp post left side
        if (gameObject.transform.name == "SidePointL")
        {
            if (rand > 0 && rand <= _object.getChanceValue((int)ObtectType.LampPost))
            {
                objectIndex = 3;
            }
        }
        //Lamp post right side
        if (gameObject.transform.name == "SidePointR")
        {
            if (rand > 0 && rand <= _object.getChanceValue((int)ObtectType.LampPost))
            {
                objectIndex = 4;
            }
        }
        // Spawn object at position of game object, which has this script attached to.
        GameObject instance = 
            Instantiate(_object.returnList()[objectIndex], transform.position, _object.returnList()[objectIndex].transform.rotation); 
        // Change y coordinate of spawned object
        instance.transform.position = 
            new Vector3(transform.position.x, _object.returnList()[objectIndex].transform.position.y, transform.position.z); 
        // Make spawned object a child of spawn point. That way spawned objects will be destroyed along with spawn point, when destroying a chunk.
        instance.transform.parent = transform; 
    }
}
