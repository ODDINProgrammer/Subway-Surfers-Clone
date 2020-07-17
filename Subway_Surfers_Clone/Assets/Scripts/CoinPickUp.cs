using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    //Variables
    [SerializeField] private int Value;  // Coin value

    //Checking, if car enters trigger collider of the coin
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<gameManager>().SetScore(Value); // Find score game object to access SetScore method
            FindObjectOfType<gameManager>().SetCoinAmount();
            Destroy(gameObject);
        }
    }
}

