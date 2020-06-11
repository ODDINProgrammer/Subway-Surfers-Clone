using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    //Variables
    [SerializeField] private int Value; // Coin value

    //Checking, if car enters trigger collider of the coin
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Car")
        {
            FindObjectOfType<HUDDisplay>().SetScore(Value); // Find canvas game object to access SetScore method
            Destroy(gameObject);
        }
    }
}

