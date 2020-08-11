using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public List<AudioSource> AudioList;
    public enum AudioType
    {
        Coin = 0,
        BGM = 1,
        Engine = 2,
        Crash = 3,
        Boom = 4,
    }
}
