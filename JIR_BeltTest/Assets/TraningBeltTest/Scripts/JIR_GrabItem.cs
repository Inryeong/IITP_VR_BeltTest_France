using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class JIR_GrabItem : MonoBehaviour
{
    // CheckZone tag에서 빠져나오면 콜라이더 isTrigger true
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "CheckZone")
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    // TrashBin에 닿으면 isTrigger 
}
