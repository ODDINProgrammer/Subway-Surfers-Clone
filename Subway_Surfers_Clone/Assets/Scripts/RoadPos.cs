using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPos : MonoBehaviour
{
    public enum Position { Left, Center, Right }; // Road position. This is used to tell the game, which part of road the player is currently at.
    public Position roadPosition;
}


