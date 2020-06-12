using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    // Variables
    public Transform Begin;                             //Begining of chunk
    public Transform End;                               //End of chunk
    [SerializeField] private int ObstaclesMinValue = 4;
    [SerializeField] private int ObstaclesMaxValue = 10;
    [SerializeField] private int ObstaclesCount;        // Stores amount of obstacles present on chunk
    [SerializeField] private int AllowedObstacleCount;  // Controlls amount of obstacles allowed on chunk

    private void Start()
    {
        AllowedObstacleCount = Random.Range(ObstaclesMinValue, ObstaclesMaxValue);
    }

    // Method to change the amount of obstacles. 
    public void ChangeObstacleAmount(int number)
    {
        ObstaclesCount += number;
    }

    // Method to receive the amount of obstacles. 
    public int GetObstacleAmount()
    {
        return ObstaclesCount;
    }

    // Method to receive the allowed amount of obstacles. 
    public int GetAllowedObstacleAmount()
    {
        return AllowedObstacleCount;
    }
}
