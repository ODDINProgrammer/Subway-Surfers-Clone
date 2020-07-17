using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Variables
    [SerializeField] private float Speed;            // Player speed 
    [SerializeField] private float SpeedStep;        // How much speed changes 
    [SerializeField] private float MaxSpeed;         // Max speed 
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
    // Animations
    [Header("Animators")]
    [SerializeField] private Animator RearFlashlights;

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
        if (FindObjectOfType<gameManager>().ReturnGameStatus() != true)
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
        if (collision.rigidbody.tag == "Obstacle")
        {
            // After hitting an obstacle car ends up a bit inside of it's model, so I put it back a bit
            transform.position -= new Vector3(0, 0, 0.5f);
            Speed = 0;       
            CarSound.Stop();
            CarCrash.Play();
            Smoke.SetActive(true);
            RearFlashlights.Play("FlashingRearLight");
            CrashSmoke.Play();
            FindObjectOfType<gameManager>().EndGame();
        }
    }

    public void SetSpeed()
    {
        Debug.Log("Called SPEEDUP!!");
        Speed += SpeedStep;
    }
}
