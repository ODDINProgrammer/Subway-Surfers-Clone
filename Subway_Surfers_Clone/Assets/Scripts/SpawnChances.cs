using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnChances : MonoBehaviour
{
    // Object chances to spawn
    [Header("Chances to spawn.")]
    [SerializeField] private int Coin = 0;
    [SerializeField] private int Wall = 0;
    [SerializeField] private int LampPost = 0;
    [SerializeField] private int WorkCones = 0;

    [SerializeField] private List<GameObject> objectList; // List that stores objects, e.g., coins, powerups.
   
    //Returns chance value to caller
    public int getChanceValue(int index)
    {
        switch(index)
        {
            default:
                return 0;
            case 1:
                return Coin;
            case 2:
                return Wall;
            case 3:
                return LampPost;
            case 4:
                return WorkCones;
        }
    }

    //Returns list to caller
    public List<GameObject> returnList()
    {
        return objectList;
    }
}
