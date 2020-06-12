using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables 
    [SerializeField] private Transform playerTransform; // Player transorm accessor
    [SerializeField] private float offset; // Used to translate camera in chosen direction. In my case a bit behind the player on z axis.
   
    // Late update method is called, after all update methods have been executed in other scripts.
    // This way I get rid of gittering screen effect.
    void LateUpdate()
    {
        transform.position = new Vector3(0, 13, playerTransform.position.z - offset); // Make camera follow player on z axis.
    }
}
