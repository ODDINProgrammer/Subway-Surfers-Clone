﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    //Variables
    [SerializeField] private float Speed; //Player speed 
    [SerializeField][Range(0f, 1f)] private float LaneChangeSpeed = 0.5f; // Speed of movement between lanes
    [SerializeField] private Vector3 NewPlayerPos; // Store position, where player will be moved to
    
    private RaycastHit hit; // Storing information of ray intersection

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * Speed * Time.deltaTime; // Moving player forward
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2); // Shoot a ray to check, which part of road player is currently at
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 2, Color.red); // Draw a ray for visual representation
        Debug.Log(hit.collider.gameObject.GetComponent<RoadPos>().roadPosition); // Output result of intersection to console

        // Change lanes by interpolation between current position and destination.
        // hit.collider.gameObject.GetComponent<RoadPos>().roadPosition accesses RoadPos class 
        // to get information, where player is currently at.
        if (Input.GetKeyDown(KeyCode.A) && hit.collider.gameObject.GetComponent<RoadPos>().roadPosition != RoadPos.Position.Left)
        {
            transform.position -= NewPlayerPos;
        }
        if (Input.GetKeyDown(KeyCode.D) && hit.collider.gameObject.GetComponent<RoadPos>().roadPosition != RoadPos.Position.Right)
        {
            transform.position += NewPlayerPos;
        }
       
    }
}
