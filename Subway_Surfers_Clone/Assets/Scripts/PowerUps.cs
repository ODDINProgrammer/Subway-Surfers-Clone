using UnityEngine;
using TMPro;

public class PowerUps : MonoBehaviour
{
    // Variables
    public enum PowerUpType
    {
        Invincibility = 1,
        CoinMadness = 2,
    }

    // Invincibility vars
    public bool Invincible = false;
    private float InvincibleTimeReset;              // Stores Invicibility timer value.
    [SerializeField] private float InvincibleTime;  // The same as InvicibleTimeReset, but this one is used in methods and being processed.
    [SerializeField] private TextMeshProUGUI InvincibleTextField;
    [SerializeField] private GameObject InvincibleTimerObject;
    // Coin Madness
    public bool CoinMadnessOn = false;
    [SerializeField] private float CoinMadnessTimer;
    private float CoinMadnessTimerReset;
    // Methods 
    private void Start()
    {
        // Store timer value, to reset it later.
        InvincibleTimeReset = InvincibleTime;
        CoinMadnessTimerReset = CoinMadnessTimer;
    }
    private void Update()
    {
        #region Invincibility
        if (InvincibleTime > 0 && Invincible)
        {
            InvincibleTime -= Time.deltaTime;
            InvincibleTextField.text = InvincibleTime.ToString("F1");
        }
        else
        {
            InvincibleTime = InvincibleTimeReset;
            Invincible = false;
            InvincibleTimerObject.SetActive(false);
        }
        #endregion
        #region CoinMadness
        if (CoinMadnessTimer > 0 && CoinMadnessOn)
        {
            CoinMadnessTimer -= Time.deltaTime;
        }
        else
        {
            CoinMadnessTimer = CoinMadnessTimerReset;
            CoinMadnessOn = false;
        }
        #endregion
    }
    public void ActivatePowerUp(int index)
    {
        switch (index)
        {
            default:
                break;
            // Invincibility 
            case 1:
                Invincible = true;
                InvincibleTimerObject.SetActive(true);
                break;
            case 2:
                CoinMadnessOn = true;
                break;


        }
    }
}

