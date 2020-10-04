using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Function : A function for recording what User continues to hold Object
/// @Date : 2020-02-25
/// </summary>
/// 

public class JIR_HandCheck : MonoBehaviour
{
    [HideInInspector]
    public int handLocomotionCheck = 0;     // The number of times your hands moved with the object

    [HideInInspector]
    public string tmpTot = "";              // Store the number of times the gun's hands moved

    public bool isTrigger = false;          // Detecting if the hand is on the area of the Bin

    // 손의 움직임 횟수를 저장하기 위한 함수
    public void TriggerCheck()
    {
        if (isTrigger)
        {
            handLocomotionCheck += 1;
            tmpTot = handLocomotionCheck.ToString();
            //JIR_EventLogger.Log(new JIR_EventLog(0,"user", "holding", "",""));

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            isTrigger = true;
            TriggerCheck();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            isTrigger = false;

        }
    }
}
