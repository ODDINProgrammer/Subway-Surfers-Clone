using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    // Variables 
    [SerializeField] private Transform playerRig;
    private bool ObstacleOnLeft = false;
    private bool ObstacleOnRight = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRig = GameObject.Find("Player").transform;
    }

    // Check for collision with obstacles.
    // In case collision exists, set bool to true and use it to restrict movement.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            // If obstacle is on the left side
            if (other.transform.position.x < transform.position.x)
            {
                ObstacleOnLeft = true;
            }
            // If obstacle is on the right side
            if (other.transform.position.x > transform.position.x)
            {
                ObstacleOnRight = true;
            }
        }
    }
    
    // Return bools to default state.
    private void OnTriggerExit(Collider other)
    {
        ObstacleOnLeft = false;
        ObstacleOnRight = false;
    }

    // Variable accessor
    public bool ReturnObstacleCheckState(int SideInt)
    {
        switch (SideInt)
        {
            default:
                return false;
            case 0:
                return ObstacleOnLeft;
            case 1:
                return ObstacleOnRight;
        }
    }


}
