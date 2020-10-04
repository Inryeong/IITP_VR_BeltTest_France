using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_S3_ConveyorManager : MonoBehaviour
{

    public bool isTestStart = false;

    JIR_TrainingStartBtn ir_startBtn;

    JIR_TraningMovingBelt ir_movingBelt;

    JIR_TraningItemManager ir_im;

    public bool isStopMoving = false;

    private void Awake()
    {

        ir_startBtn = GameObject.Find("pCylinder96 3").GetComponent<JIR_TrainingStartBtn>();
        ir_movingBelt = GameObject.Find("Conveyor01Belt").GetComponent<JIR_TraningMovingBelt>();
        ir_im = GameObject.Find("ItemManager").GetComponent<JIR_TraningItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 버튼이 눌러졌고, item이 존재한다면
        if (ir_startBtn.isTouch == true)
        {
            // test가 시작됨을 알림
            isTestStart = true;
            // Belt 움직이도록
            ir_movingBelt.Moving();
        }

        if (ir_im.isClear == true)
        {
            // test가 시작됨을 알림
            isTestStart = false;
            // Belt 움직이도록
            ir_movingBelt.StopMoving();

            isStopMoving = true;
        }


    }

}