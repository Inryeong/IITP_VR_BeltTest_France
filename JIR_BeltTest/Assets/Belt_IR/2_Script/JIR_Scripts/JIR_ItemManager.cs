using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// @Function : Object를 랜덤하게 생성하도록 관리
/// @Data : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>
/// 
public class JIR_ItemManager : MonoBehaviour
{
    JIR_StartButton ir_statBtn;
    JIR_ConveyorManager ir_conveyorMgr;

    public Transform[] spawnPositions;          // 오브젝트가 생성될 세 군데 위치 배열

    public GameObject[] items;                  // 랜덤한 아이템들 배열

    public float createTime = 8f;               // 생성 시간
    float currentTime = 0;                      // 경과 시간

    private void Awake()
    {
        ir_statBtn = GameObject.Find("pCylinder96 3").GetComponent<JIR_StartButton>();
        ir_conveyorMgr = GameObject.Find("ConveyorManager").GetComponent<JIR_ConveyorManager>();
    }

    private void Update()
    {
        if (ir_statBtn.isTouch)
        {
            if (ir_conveyorMgr.isStop == false)
            {
                CreateItems();
            }
        }
    }

    // 오브젝트가 중복되지 않게 랜덤하게 섞는 함수
    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        // prng = pseudorandom number generator : 유사난수생성기
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }

    // 랜덤한 위치에 오브젝트 생성해주는 함수
    void CreateItems()
    {
        currentTime += Time.deltaTime;

        for (int i = 0; i < ir_conveyorMgr.stopTime; i++)
        {
            if (currentTime >= createTime)
            {
                currentTime = 0;

                int index = Random.Range(0, spawnPositions.Length);
                GameObject[] selectedItem = items;
                ShuffleArray(selectedItem, 1000);
                GameObject item = selectedItem[Random.Range(0, selectedItem.Length)];
                Instantiate(item, spawnPositions[index].position, item.transform.rotation);
            }
        }
    }
}
