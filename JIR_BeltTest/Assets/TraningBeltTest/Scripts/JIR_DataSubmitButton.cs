using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class JIR_DataSubmitButton : MonoBehaviour
{


    public void StartButtonClick()
    {

        Debug.Log("Next Scene Load");
        JIR_LoadingScene.Instance.LoadScene("BeltTest_S1");
    }

    //public void SetUserID()
    //{
    //    PlayerPrefs.SetString("uid", uid.text);   
    //}

    //public void GetUserID()
    //{
    //    PlayerPrefs.GetString("uid");
    //}

    //public void SetBeltSpeed()
    //{
    //    PlayerPrefs.SetFloat("beltSpeed", speed.value);
    //}

    //public float GetBeltSpeed()
    //{
    //    Debug.Log(PlayerPrefs.GetFloat("beltSpeed"));
    //    return PlayerPrefs.GetFloat("beltSpeed");
    //}

    //public void SetInterval()
    //{
    //    PlayerPrefs.SetFloat("interval", interval.value);
    //}
    
}
