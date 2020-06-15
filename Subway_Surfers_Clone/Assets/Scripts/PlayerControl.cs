using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    // Variables
    [SerializeField] private float Speed;                                 //Player speed 
    [SerializeField][Range(0f, 1f)] private float LaneChangeSpeed = 0.5f; // Speed of movement between lanes
    [SerializeField] private Vector3 NewPlayerPos;                        // Store position, where player will be moved to
    // Sounds
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource CarSound;
    // Storing information of ray intersection
    private RaycastHit hitDown; 
    // Collieders
    [SerializeField] private Collider LeftCollider;
    [SerializeField] private Collider RightCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime; // Moving player forward
        // Creating ray
        Ray rayDown = new Ray(transform.position, transform.TransformDirection(Vector3.down));
        // Shooting ray
        Physics.Raycast(rayDown, out hitDown, 2); 
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 2, Color.red); // Draw a ray for visual representation
        // Change lanes by interpolation between current position and destination.
        // hit.collider.gameObject.GetComponent<RoadPos>().roadPosition accesses RoadPos class 
        // to get information, where player is currently at.
        if (Input.GetKeyDown(KeyCode.A) && 
            hitDown.collider.gameObject.GetComponent<RoadPos>().roadPosition != RoadPos.Position.Left)
        {
            transform.position -= NewPlayerPos;
        }
        if (Input.GetKeyDown(KeyCode.D) && 
            hitDown.collider.gameObject.GetComponent<RoadPos>().roadPosition != RoadPos.Position.Right)
        {
            transform.position += NewPlayerPos;
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        // Playing coin sound
        if (other.tag == "Coin")
        {
            CoinSound.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Routine for interaction with obstacle
        if (collision.rigidbody.tag == "Obstacle")
        {
            Speed = 0;        // Stop the player
            CarSound.Stop();
        }
    }
}
