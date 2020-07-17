using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // Variables
    public enum PowerUpType
    {
        Invincibility = 1,
        CoinMadness = 2,
    }

    // Invincibility vars
    private bool Invincible = false;
    private float InvincibleTimeReset;              // Stores Invicibility timer value.
    [SerializeField] private float InvincibleTime;  // The same as InvicibleTimeReset, but this one is used in methods and being processed.

    // Methods 
    private void Start()
    {
        // Store timer value, to reset it later.
        InvincibleTimeReset = InvincibleTime;
    }
    private void Update()
    {
        // Set invincibility timer
        if (Invincible == true && InvincibleTime > 0)
        {
            InvincibleTime -= Time.deltaTime;
        }
        else
        {
            // Reset timer for next use.
            InvincibleTime = InvincibleTimeReset;
            Invincible = false;                         
        }
    }
    public void ActivatePowerUp(int index)
    {
        switch(index)
        {
            default:
                break;
            // Invincibility 
            case 1:
                Invincible = true;
                break;


        }
    }

    public bool InvincibilityActive()
    {
        return Invincible;
    }
}

