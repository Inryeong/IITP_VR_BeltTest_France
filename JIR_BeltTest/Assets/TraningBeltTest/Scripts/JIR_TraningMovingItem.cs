using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_TraningMovingItem : MonoBehaviour
{
    public Transform endpoint;

    JIR_TraningMovingBelt ir_data;

    private void Awake()
    {
        ir_data = GameObject.Find("Conveyor01Belt").GetComponent<JIR_TraningMovingBelt>();
        
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            // The object moves to end of the 'endpoint' location.
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, endpoint.position, ir_data.speed * Time.deltaTime);
        }
    }
}