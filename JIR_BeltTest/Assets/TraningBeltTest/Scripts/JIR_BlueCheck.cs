using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// function 1 : item을 넣을 수 있는 상태인지 시각적으로 알려줌
/// function 2 : 어떤 tag를 가진 item이 닿았는지 data 수집
/// function 3 : 
/// </summary>
public class JIR_BlueCheck : MonoBehaviour
{
    Image labelImg;
    Color originColor;

    public int totHandHesitation = 0;
    int tempHandHesitation = 0;


    // Start is called before the first frame update
    void Start()
    {

        labelImg = GameObject.Find("BlueImage").GetComponent<Image>();
        originColor = labelImg.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Item"))
        {
            labelImg.color = Color.blue;
            tempHandHesitation += 1;

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Item"))
        {
            labelImg.color = originColor;
            totHandHesitation = tempHandHesitation;
            Debug.Log("Hand : " + tempHandHesitation);
        }
    }
}
