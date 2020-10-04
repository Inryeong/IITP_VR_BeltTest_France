using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Examples;

public class JIR_S1_CheckAction : MonoBehaviour
{



    //잡은 뒤로부터의 누적 시간

    public float actionTime;


    public Vector3 cumulativeLeft_ControllorPos;
    public Vector3 cumulativeRight_ControllorPos;

    public float tempTime;


    public Vector3 tempLeft_ControllorPos;
    public Vector3 tempRight_ControllorPos;


    JIR_S1_GetRawData ir_s1_raw_data;

    JIR_BlueCheck ir_blueCheck;
    JIR_YellowCheck ir_yellowCheck;
    JIR_RedCheck ir_redCheck;
    JIR_GreenCheck ir_greenCheck;



    private void Awake()
    {
        ir_s1_raw_data = GameObject.Find("DataManager").GetComponent<JIR_S1_GetRawData>();

        ir_blueCheck = GameObject.Find("BlueCheck").GetComponent<JIR_BlueCheck>();
        ir_yellowCheck = GameObject.Find("YellowCheck").GetComponent<JIR_YellowCheck>();
        ir_redCheck = GameObject.Find("RedCheck").GetComponent<JIR_RedCheck>();
        ir_greenCheck = GameObject.Find("GreenCheck").GetComponent<JIR_GreenCheck>();


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Item"))
        {
            // 데이터 저장했으면 초기화
            tempTime = 0;
            actionTime = 0;

            ir_blueCheck.totHandHesitation = 0;
            ir_redCheck.totHandHesitation = 0;
            ir_yellowCheck.totHandHesitation = 0;
            ir_greenCheck.totHandHesitation = 0;

            tempRight_ControllorPos = Vector3.zero;
            tempLeft_ControllorPos = Vector3.zero;
            cumulativeRight_ControllorPos = Vector3.zero;
            cumulativeLeft_ControllorPos = Vector3.zero;

            S1_User_Log.Log("User", "Get", other.gameObject.tag.ToString(),"","","","","","", "", "","","","");


        }

    }


    private void OnTriggerStay(Collider other)
    {
        // 1-1. item이 controller 트리거됐다면

        if (other.gameObject.name.Contains("Item"))
        {
            Debug.Log("--- start action ---");
            
            tempTime += Time.deltaTime;

            tempLeft_ControllorPos.x += Mathf.Abs(ir_s1_raw_data.left_ControllorPos.x);
            tempLeft_ControllorPos.y += Mathf.Abs(ir_s1_raw_data.left_ControllorPos.y);
            tempLeft_ControllorPos.z += Mathf.Abs(ir_s1_raw_data.left_ControllorPos.z);

            tempRight_ControllorPos.x += Mathf.Abs(ir_s1_raw_data.right_ControllerPos.x);
            tempRight_ControllorPos.y += Mathf.Abs(ir_s1_raw_data.right_ControllerPos.y);
            tempRight_ControllorPos.z += Mathf.Abs(ir_s1_raw_data.right_ControllerPos.z);

            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Item"))
        {

            Debug.Log("--- stop action ---");

            actionTime = tempTime;


            cumulativeRight_ControllorPos = tempRight_ControllorPos;
            
            cumulativeLeft_ControllorPos = tempLeft_ControllorPos;

            S1_User_Log.Log("User", "Drop", other.gameObject.tag.ToString(), ir_yellowCheck.totHandHesitation.ToString(),
                            ir_blueCheck.totHandHesitation.ToString(), ir_redCheck.totHandHesitation.ToString(),
                            ir_greenCheck.totHandHesitation.ToString(), "", "",
                            cumulativeLeft_ControllorPos.ToString(), cumulativeRight_ControllorPos.ToString(), actionTime.ToString("f3"), "", "");

        }

    }
}
