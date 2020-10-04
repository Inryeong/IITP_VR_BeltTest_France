using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading;
using VRTK;
using UnityEngine.UI;
using System.Text;

/// <summary>
///  @Function : Vive 헤드셋, Vive 컨트롤러 데이터 레코딩
///  @Date: 2020-03-19
///  @History
///     2020-03-19 : 최초 작성
/// </summary>

public class JIR_S1_GetRawData : MonoBehaviour
{


    private Transform headset;          // Vive Headset 위치
    private Transform left_Controller;  // 왼쪽 vive controller 위치
    private Transform right_Controller; //오른쪽 vive controller 위치

    public Vector3 headsetPos;             // Vive Headset 위치값 저장
    public Vector3 left_ControllorPos;     // Vive Left controller 위치값 저장
    public Vector3 right_ControllerPos;    // Vive Right controller 위치값 저장

    public Quaternion headsetRot;          // Vive Headset 회전
    public Quaternion left_ControllerRot;  // Vive Left Controller 회전
    public Quaternion right_ControllerRot; // Vive Right controller 회전

    // 어플리케이션이 실행이 되면 로드된 기기들의 정보를 받기 위해 VRTK_SDKManger를 통해 불러온다.
    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
        VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);

        //ir_data = GameObject.Find("DataManager").GetComponent<JIR_DataToCsv>();

    }

    // 어플리케이션의 실행이 끝나면 로드된 기기들을 제거한다.
    protected virtual void OnDestroy()
    {
        VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
    }

    //VRTK에 로드된 디바이스들을 찾아 위치들을 vector 형식으로 변환해서 위치값을 저장한다.
    private void OnEnable()
    {
        headset = VRTK_DeviceFinder.HeadsetTransform();
        left_Controller = VRTK_DeviceFinder.GetControllerLeftHand().transform;
        right_Controller = VRTK_DeviceFinder.GetControllerRightHand().transform;

 

    }


    // 매 프레임마다 위치값과 회전값을 디버깅한다.
    void Update()
    {
        headsetPos = headset.position;
        left_ControllorPos = left_Controller.position;
        right_ControllerPos = right_Controller.position;

        headsetRot = headset.rotation;
        left_ControllerRot = left_Controller.rotation;
        right_ControllerRot = right_Controller.rotation;

        // Log_Controller.Log((Mathf.Round(headset.position.x * 10) * 0.00001f).ToString());
        S1_Raw_Log.Log(headsetPos.x.ToString("f3") + ";" + headsetPos.y.ToString("f3") + ";" + headsetPos.z.ToString("f3") + ";" +
                        right_ControllerPos.x.ToString("f3") + ";" + right_ControllerPos.y.ToString("f3") + ";" + right_ControllerPos.z.ToString("f3") + ";" +
                        left_ControllorPos.x.ToString("f3") + ";" + left_ControllorPos.y.ToString("f3") + ";" + left_ControllorPos.z.ToString("f3") + ";" +
                        headsetRot.x.ToString("f3") + ";" + headsetRot.y.ToString("f3") + ";" + headsetRot.z.ToString("f3") + ";" + headsetRot.w.ToString("f3") + ";" +
                        right_ControllerRot.x.ToString("f3") + ";" + right_ControllerRot.y.ToString("f3") + ";" + right_ControllerRot.z.ToString("f3") + ";" + right_ControllerRot.w.ToString("f3") + ";" +
                        left_ControllerRot.x.ToString("f3") + ";" + left_ControllerRot.y.ToString("f3")+ ";" + left_ControllerRot.z.ToString("f3") + ";" + left_ControllerRot.w.ToString("f3"));




    }


}
