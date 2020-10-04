using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_LeftControlController : MonoBehaviour
{

    public SphereCollider ir_r_cc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "StartBtn")
        {
            gameObject.GetComponent<SphereCollider>().radius = 0.8f;
            ir_r_cc.GetComponent<SphereCollider>().radius = 0.8f;
        }
    }

}
