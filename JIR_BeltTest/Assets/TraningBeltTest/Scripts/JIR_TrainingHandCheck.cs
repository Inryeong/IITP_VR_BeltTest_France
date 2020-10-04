using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JIR_TrainingHandCheck : MonoBehaviour
{
    public bool isRedCheck = false;
    public bool isBlueCheck = false;
    public bool isGreenCheck = false;
    public bool isYellowCheck = false;



    // 1. item을 잡은 손이 위에 있다면 라벨 색 다르게 보여주기
    Image imgColor;
    Color originColor;

    // Start is called before the first frame update
    void Start()
    {

        imgColor = GetComponentInParent<Image>();
        originColor = imgColor.color;

    }

    // Update is called once per frame
    void Update()
    {
        if(isRedCheck == true)
        {
            imgColor.color = Color.red;
        }
        else if(isBlueCheck == true)
        {
            imgColor.color = Color.blue;
        }
        else if(isGreenCheck == true)
        {
            imgColor.color = Color.green;
        }
        else if(isYellowCheck == true)
        {
            imgColor.color = Color.yellow;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            imgColor.color = Color.white;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            imgColor = GetComponentInParent<Image>();

            imgColor.color = originColor;
        }
    }
}
