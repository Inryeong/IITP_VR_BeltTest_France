using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    Vector3 headsetSpeed;

    private void Start()
    {
        headsetSpeed = GetComponent<Rigidbody>().angularVelocity;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
