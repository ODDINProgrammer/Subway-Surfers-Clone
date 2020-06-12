using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables 
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, 13, playerTransform.position.z - offset); // Make camera follow player on z axis.
    }
}
