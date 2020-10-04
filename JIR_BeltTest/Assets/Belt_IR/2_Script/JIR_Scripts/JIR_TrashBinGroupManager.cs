using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JIR_TrashBinGroupManager : MonoBehaviour
{
    // 랜덤하게 Can, Plastic, Glass, Paper 텍스트를 설정하고 싶다
    // - 4 가지 텍스트 필요
    public List<string> stringList = new List<string>();

    public List<Text> textList = new List<Text>();
    
    private void Awake()
    {
        stringList.Add("Can");
        stringList.Add("Plastic");
        stringList.Add("Glass");
        stringList.Add("Paper");

        stringList = ShuffleList(stringList);

        textList[0].text = stringList[0];
        textList[1].text = stringList[1];
        textList[2].text = stringList[2];
        textList[3].text = stringList[3];
    }

    public static List<string> ShuffleList(List<string> _list)
    {
        //items 리스트의 수만큼
        for (int i = 0; i < _list.Count; i++)
        {
            string temp = _list[i];
            int randomIndex = Random.Range(0, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }
        return _list;
    }

}
