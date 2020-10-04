using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Function : Belt Test Session 을 관리하기 위한 함수
/// @Date : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>
/// 

public class JIR_ConveyorManager : MonoBehaviour
{
    [HideInInspector]
    public bool isStop = false;                    // 실험 중단 여부

    JIR_TrainingStartBtn ir_statBtn;
    JIR_MovingBelt ir_movingBelt;

    float currentTime = 0;                  // 경과 시간
    public float speed = 1.5f;              // Belt의 속도
    public float stopTime = 3000f;            // 실험 중단 조건 시간


    private void Awake()
    {
        ir_statBtn = GameObject.Find("pCylinder96 3").GetComponent<JIR_TrainingStartBtn>();
        ir_movingBelt = GameObject.Find("Conveyor01Belt").GetComponent<JIR_MovingBelt>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ir_statBtn.isTouch)
        {
            Test();

        }
    }

    // 실험 종료 시간이 되기 전까지 실험이 진행되도록 해주는 함수
    void Test()
    {
        currentTime += Time.deltaTime;

        if ( isStop == false && currentTime >= stopTime)
        {

            currentTime = 0;
            isStop = true;
            speed = 0;
        }
    }
}
