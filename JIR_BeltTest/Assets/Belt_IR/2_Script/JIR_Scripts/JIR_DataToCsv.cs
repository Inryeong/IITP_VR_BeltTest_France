using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Function : User Behavial Data 레코딩
/// @Data : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>
/// 

public class JIR_DataToCsv : MonoBehaviour
{


    [HideInInspector]
    public string headPosX;
    [HideInInspector]
    public string response;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfYY-PE-dU901Jzb-pRcjRRGaabxIgKx2dVs0rRgIuVtAxHyw/formResponse";

    public void Send()
    {
        StartCoroutine(Post(headPosX, response));
    }

    IEnumerator Post(string headPosX, string response)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.699207610", headPosX);
        form.AddField("entry.1585296973", response);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;

    }
}
