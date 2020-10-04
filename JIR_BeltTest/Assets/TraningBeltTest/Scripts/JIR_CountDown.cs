using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JIR_CountDown : MonoBehaviour
{
    // 0. 버튼이 눌러졌는가?
    JIR_TrainingStartBtn ir_Startbtn;


    // 나는 3초가 지나면 Belt를 움직이게 하고 싶다
    // 1. 3초 카운트 다운을 시각화 하고 싶다

    // 1-1 . 시간이 흘러야 한다.
    // - 경과 시간
    float timer = 0f;

    // - timer
    public float totTime;
    float startTime;

    public Text text;

    // CM한테 시작 신호를 알려줘야해
    public bool isCountDownDone = false;

    private void Awake()
    {
        ir_Startbtn = GameObject.Find("pCylinder96 3").GetComponent<JIR_TrainingStartBtn>();
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.color = Color.white;
        startTime = totTime;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 버튼이 눌러졌다면
        if (ir_Startbtn.isTouch == true)
        {
            //2. Timer 시작
            CountDownStart();
        }


        //3. 만약 Item이 모두 나왔다면
        //4. 게임 종료 알림
    }

    void CountDownStart()
    {
        totTime -= Time.deltaTime;

        timer = (int)(totTime % 60);

        if(timer > 0)
        {
            text.text = timer.ToString();
        }
        if(timer == 0)
        {
            totTime = 0;
            text.text = "";
            isCountDownDone = true;
        }
    }


}
