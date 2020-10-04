using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_S2_BluePlasticBin : MonoBehaviour
{

    public int correct = 0;
    public int incorrect = 0;

    public int interferenceResponse = 0;
    public string response;

    public float destroyTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        correct = 0;
        incorrect = 0;
        interferenceResponse = 0;

        response = gameObject.tag.ToString();

        if (other.gameObject.name.Contains("Item"))
        {
            //만약 item에 glass가 포함된 아이템으로 응답했다면
            if (other.gameObject.name.Contains("Plastic"))
            {
                // 맞다면 correct 표시
                correct = 1;
            }
            else
            {
                // 아니라면 incorrect 표시
                incorrect = 1;

                if (other.gameObject.name.Contains("Blue"))
                {
                    interferenceResponse = 1;
                }
            }

            S2_User_Log.Log("System", "Get", other.gameObject.tag.ToString(), "", "", "", "", response, interferenceResponse.ToString(), "", "", "", incorrect.ToString(), correct.ToString());


            Destroy(other.gameObject, destroyTime);
        }
    }
}
