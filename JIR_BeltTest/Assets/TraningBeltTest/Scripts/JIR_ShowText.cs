using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JIR_ShowText : MonoBehaviour
{
    public Text text;

    public void TextUpdate(float value)
    {
        text.text = (Mathf.Round(value * 10) * 0.1f).ToString();
    }

    
}
