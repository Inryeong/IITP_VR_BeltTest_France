using System;
using System.IO;
using System.Text;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// @Function : User Behavial Data 레코딩
/// @Data : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>
/// 

public class JIR_EventLog
{

    private string actor;
    //private EventCategory category;
    private string eventType;
    private string objectName;
    //private Dictionary<string, string> attributes;
    private string response;

    //public JIR_EventLog(EventCategory category, string actor, string eventType, string objectName, string response)
    //{
    //    this.category = category;
    //    this.actor = actor;
    //    this.eventType = eventType;
    //    this.objectName = objectName;
    //    this.response = response;
    //    //this.attributes = attributes;
    //}

    //public override string ToString()
    //{
       
    //    return string.Format("{0};{1};{2};{3};{4}", this.category, this.actor, this.eventType, this.objectName, this.response);
    //}

}

public class JIR_EventLogger : MonoBehaviour
{
    private DateTime datetimeNow;

    private static readonly object innerLock = new object();
    //private static string path = "EventLog" + DateTime.Now + ".csv";
    private static string path = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss") + "-EventLog.csv";

    //use this for initialization
    void OnEnable()
    {

        File.AppendAllText(path, "Apptime;EventCategory;Actor;EventType;Object;Response\n", Encoding.UTF8);
    }

    public static void Log(JIR_EventLog e)
    {

        Debug.Log(e.ToString());
        lock (innerLock)
        {
            File.AppendAllText(path, String.Format("{0};{1};\n", DateTime.Now ,e.ToString()), Encoding.UTF8);
        }
    }
}
