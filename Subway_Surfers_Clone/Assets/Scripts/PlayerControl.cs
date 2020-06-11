using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Variables
    [SerializeField] private float Speed; //Player speed 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * Speed * Time.deltaTime; //Moving player forward
    }
}
