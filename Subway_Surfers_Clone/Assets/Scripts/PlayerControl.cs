using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    // Variables
    [SerializeField] private float Speed;            // Player speed 
    [SerializeField] private Vector3 NewPlayerPos;   // Store position, where player will be moved to
    // Sounds
    [Header("Sounds")]
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource CarSound;
    [SerializeField] private AudioSource CarCrash;
    // Particles
    [Header("Particles")]
    [SerializeField] private ParticleSystem CrashSmoke;
    // References
    [Header("Game objects references")]
    [SerializeField] private GameObject Smoke;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime; // Moving player forward
        // Creating ray
        Ray rayDown = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        // Storing information of ray intersection
        RaycastHit hitDown;
        int raySize = 2;
        // Shooting ray
        Physics.Raycast(rayDown, out hitDown, raySize); 
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * raySize, Color.red); // Draw a ray for visual representation
        // hit.collider.gameObject.GetComponent<RoadPos>().roadPosition accesses RoadPos class 
        // to get information, where player is currently at. It restricts movement if player
        // is currently at left or right sides of road.
        // It also restricts movement, if there is an obstacle in the way. (0 - Left check, 1 - Right check)
        if (FindObjectOfType<gameManager>().GameOver() != true)
        {
            if (Input.GetKeyDown(KeyCode.A) &&
                hitDown.collider.gameObject.GetComponent<RoadPos>().roadPosition != RoadPos.Position.Left &&
                FindObjectOfType<ObstacleCheck>().ReturnObstacleCheckState(0) != true)
            {
                transform.position -= NewPlayerPos;
            }
            if (Input.GetKeyDown(KeyCode.D) &&
                hitDown.collider.gameObject.GetComponent<RoadPos>().roadPosition != RoadPos.Position.Right &&
                FindObjectOfType<ObstacleCheck>().ReturnObstacleCheckState(1) != true)
            {
                transform.position += NewPlayerPos;
            }
        }
    }

    // Coin pickup
    private void OnTriggerEnter(Collider other)
    {
        // Playing coin sound
        if (other.tag == "Coin")
        {
            CoinSound.Play();
        }
    }

    // Check if player rides into obstacle
    private void OnCollisionEnter(Collision collision)
    {
        /*// Create a ray infront of the car, to check, if it hit any type of obstacle 
        Ray rayForward = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        // Storing information of ray intersection
        RaycastHit hitForward;
        int raySize = 4;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raySize, Color.red);
        // Routine for interaction with obstacle
        // Physics.Raycast returns true, if ray intersected collider && Physics.Raycast(rayForward, out hitForward, raySize)
        */
        if (collision.rigidbody.tag == "Obstacle")
        {
            Speed = 0;        // Stop the player
            CarSound.Stop();
            CarCrash.Play();
            Smoke.SetActive(true);
            CrashSmoke.Play();
            FindObjectOfType<gameManager>().EndGame();
        }
    }
}
