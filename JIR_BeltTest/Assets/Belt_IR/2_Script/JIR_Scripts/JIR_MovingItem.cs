using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Function : Object가 Belt의 속도에 따라 움직이도록 만드는 함수
/// @Data : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>

public class JIR_MovingItem : MonoBehaviour
{
    public Transform endpoint;      // 오브젝트의 중력 적용 지점

    JIR_ConveyorManager ir_cm;

    private void Awake()
    {
        ir_cm = GameObject.Find("ConveyorManager").GetComponent<JIR_ConveyorManager>();

    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            collision.transform.position = Vector3.MoveTowards(collision.transform.position, endpoint.position, ir_cm.speed * Time.deltaTime);   // The object moves to end of the 'endpoint' location.
        }
    }
}
