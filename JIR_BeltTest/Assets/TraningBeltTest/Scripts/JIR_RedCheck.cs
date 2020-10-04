using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JIR_RedCheck : MonoBehaviour
{
    Image labelImg;
    Color originColor;

    public int totHandHesitation = 0;
    int tempHandHesitation = 0;

    // Start is called before the first frame update
    void Start()
    {
        labelImg = GameObject.Find("RedImage").GetComponent<Image>();
        originColor = labelImg.color;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Item"))
        {
            labelImg.color = Color.red;
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
