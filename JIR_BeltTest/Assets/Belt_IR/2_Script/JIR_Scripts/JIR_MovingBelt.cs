using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Function : Belt를 움직이는 함수
/// @Date : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>
/// 

public class JIR_MovingBelt : MonoBehaviour
{
    JIR_TrainingStartBtn ir_statBtn;
    JIR_ConveyorManager ir_cm;

    private void Awake()
    {
        ir_cm = GameObject.Find("ConveyorManager").GetComponent<JIR_ConveyorManager>();
        ir_statBtn = GameObject.Find("pCylinder96 3").GetComponent<JIR_TrainingStartBtn>();
    }

    private void Update()
    {
        if(ir_statBtn.isTouch == true)
        {
            Invoke("StartMoving", 2.5f);
        }

    }

    // A function that moves Belt 2.5 seconds after receiving an experiment start call
    public void StartMoving()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset += Vector2.up * ir_cm.speed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
