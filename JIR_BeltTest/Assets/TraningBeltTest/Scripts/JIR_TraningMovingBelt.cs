using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_TraningMovingBelt : MonoBehaviour
{
    public float speed;
    JIR_TraningItemManager ir_im;

    public float curTime = 0;

    MeshRenderer mr;
    Material mat;
    Vector2 offset;

    private void Awake()
    {
        
        ir_im = GameObject.Find("ItemManager").GetComponent<JIR_TraningItemManager>();
    }

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        offset = mat.mainTextureOffset;
    }

    /// <summary>
    /// Belt를 움직이기 위한 함수
    /// </summary>
    public void Moving()
    {
        curTime += Time.deltaTime;

        if (curTime < speed)
        {
            offset += Vector2.up * curTime * Time.deltaTime;
            mat.mainTextureOffset = offset;
        }
        if (curTime >= speed)
        {
            curTime = speed;
            offset += Vector2.up * curTime * Time.deltaTime;
            mat.mainTextureOffset = offset;
        }
    }

    /// <summary>
    /// Belt를 멈추는 함수
    /// </summary>
    public void StopMoving()
    {

        curTime -= Time.deltaTime;

        curTime = (int)(curTime % 60);

        if (curTime > 0)
        {
            offset += Vector2.up * curTime * Time.deltaTime;
            mat.mainTextureOffset = offset;
        }

        if (curTime == 0)
        {
            curTime = 0;
            offset = Vector2.up * curTime * Time.deltaTime;
            mat.mainTextureOffset = offset;
        }
    }
}