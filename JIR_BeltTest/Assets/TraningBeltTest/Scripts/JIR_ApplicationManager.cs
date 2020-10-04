using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_ApplicationManager : MonoBehaviour
{
    JIR_HelpButton ir_helpBtn;

    JIR_S3_ConveyorManager ir_s3_cm;

    private void Awake()
    {
        ir_helpBtn = GameObject.Find("HelpButton").GetComponent<JIR_HelpButton>();
        ir_s3_cm = GameObject.Find("ConveyorManager").GetComponent<JIR_S3_ConveyorManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A) || ir_helpBtn.isPressed == true)
        {
            QuitTest();
        }

        if(ir_s3_cm.isStopMoving == true)
        {
            Application.Quit();
        }

    }

    void OnApplicationQuit()
    {
        // todo : 어플리케이션을 종료하는 순간에 처리할 행동들
        //Debug.Log("End Test Time : " + Time.deltaTime);
    }

    public void QuitTest()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
