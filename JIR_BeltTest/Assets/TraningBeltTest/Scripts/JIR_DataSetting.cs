using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JIR_DataSetting : MonoBehaviour
{
    public InputField userid;
    public Slider speed;
    public Slider interval;

    public string _uid;
    public float _speed;
    public float _interval;

    public void Save()
    {
        PlayerPrefs.SetString("userid", userid.text);
        PlayerPrefs.SetFloat("speed", speed.value);
        PlayerPrefs.SetFloat("interval", interval.value);


    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("userid"))
        {
            userid.text = PlayerPrefs.GetString("userid");
            speed.value = PlayerPrefs.GetFloat("speed");
            interval.value = PlayerPrefs.GetFloat("interval");


        }
    }
}