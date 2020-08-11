using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Variables
    [SerializeField] private float Speed;            // Player speed 
    [SerializeField] private float SpeedStep;        // How much speed changes 
    [SerializeField] private float MaxSpeed;         // Max speed 
    [SerializeField] private Vector3 NewPlayerPos;   // Store position, where player will be moved to
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

    // Pick up collectibles method
    private void OnTriggerEnter(Collider other)
    {
        // Playing coin sound
        if (other.tag == "Coin")
        {
            FindObjectOfType<SoundHandler>().AudioList[(int)SoundHandler.AudioType.Coin].Play();
        }
        // Invincibility 
        if (other.tag == "PowerUps" && other.name == "Invinciblility")
        {
            Debug.Log("Picked up Invincibility powerup!");
            FindObjectOfType<PowerUps>().ActivatePowerUp((int)PowerUps.PowerUpType.Invincibility);
            Destroy(other.gameObject);
        }
        // CoinMadness
        if (other.tag == "PowerUps" && other.name == "CoinMadness")
        {
            Debug.Log("Picked up CoinMadness powerup!");
            FindObjectOfType<PowerUps>().ActivatePowerUp((int)PowerUps.PowerUpType.CoinMadness);
            Destroy(other.gameObject);
        }
    }

    // Check if player rides into obstacle
    private void OnCollisionEnter(Collision collision)
    {
        // Normal collision method
        if (collision.rigidbody.tag == "Obstacle" && FindObjectOfType<PowerUps>().Invincible == false)
        {
            // After hitting an obstacle car ends up a bit inside of it's model, so I put it back a bit
            transform.position -= new Vector3(0, 0, 0.5f);
            Speed = 0;
            FindObjectOfType<SoundHandler>().AudioList[(int)SoundHandler.AudioType.Engine].Stop();
            FindObjectOfType<SoundHandler>().AudioList[(int)SoundHandler.AudioType.Crash].Play();
            Smoke.SetActive(true);
            RearFlashlights.Play("FlashingRearLight");
            CrashSmoke.Play();
            FindObjectOfType<gameManager>().EndGame();
        }
        // Invincibility mode collision method
        else if(collision.rigidbody.tag == "Obstacle" && FindObjectOfType<PowerUps>().Invincible == true)
        {
            FindObjectOfType<SoundHandler>().AudioList[(int)SoundHandler.AudioType.Boom].Play();
            Destroy(collision.gameObject);
        }
    }

    public void SetSpeed()
    {
        Speed += SpeedStep;
    }
}
