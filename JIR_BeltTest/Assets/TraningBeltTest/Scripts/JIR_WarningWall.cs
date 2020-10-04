using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_WarningWall : MonoBehaviour
{
    JIR_TraningConveyorManager ir_cm;
    JIR_S3_ConveyorManager ir_s3_cm;

    private void Awake()
    {
        ir_cm = GameObject.Find("ConveyorManager").GetComponent<JIR_TraningConveyorManager>();
        ir_s3_cm = GameObject.Find("ConveyorManager").GetComponent<JIR_S3_ConveyorManager>();
    }
    private void Update()
    {
        if (ir_cm.isTestStart == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (ir_s3_cm.isTestStart == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("HandCollider"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("HandCollider"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
