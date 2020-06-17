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
        LampPost = 3,
        WorkCones = 4
    }
    private SpawnChances _object;

    // Start is called before the first frame update
    void Start()
    {
        _object = FindObjectOfType<SpawnChances>();
        // Object Generation routine 
        // Generate random number to decide, which object to spawn.
        int Chance = Random.Range(0, 100);
        // Define chances of objects to be spawned 
        #region Object spawn chances 
        // Coin
        if (Chance > 0 && Chance <= _object.getChanceValue((int)ObtectType.Coin))
        {
            objectIndex = 1;
        }
        // Obstacles
        if (gameObject.transform.name == "ObstaclePoint")
        {
            int PickObstacle = Random.Range(0, 100);
            Debug.Log("Picked object: " + PickObstacle);
            // Wall
            if (PickObstacle > 0 && PickObstacle <= 50)
            {
                if (Chance > 0 && Chance <= _object.getChanceValue((int)ObtectType.Wall))
                {
                    objectIndex = 2;
                }
            }
            // Cones
            if (PickObstacle > 50 && PickObstacle <= 100)
            {
                if (Chance > 0 && Chance <= _object.getChanceValue((int)ObtectType.WorkCones))
                {
                    objectIndex = 5;
                }
            }
        }
        //Lamp post left side
        if (gameObject.transform.name == "SidePointL")
        {
            if (Chance > 0 && Chance <= _object.getChanceValue((int)ObtectType.LampPost))
            {
                objectIndex = 3;
            }
        }
        //Lamp post right side
        if (gameObject.transform.name == "SidePointR")
        {
            if (Chance > 0 && Chance <= _object.getChanceValue((int)ObtectType.LampPost))
            {
                objectIndex = 4;
            }
        }
        #endregion
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
