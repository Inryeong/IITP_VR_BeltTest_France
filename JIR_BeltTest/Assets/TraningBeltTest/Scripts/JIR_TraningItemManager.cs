using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_TraningItemManager : MonoBehaviour
{


    JIR_CountDown ir_CountDown;

    JIR_TrainingStartBtn ir_startBtn;

    private int prev=0;
    public Transform[] spawnPoints;

    public float createTime = 8f;               // 생성 시간
    float currentTime = 0;                      // 경과 시간

    public List<GameObject> itemList;           // Item 프리팹 오브젝트 풀링

    GameObject itemIndex;

    // 아이템 존재 여부
    public bool isClear = false;

    public float stopWaitTime = 5;

    // 1. 태어날 때 한 번 itemList에 들어간 gameObject들을 랜덤한 순서와 이전에 생성된 위치와 중복되지 않는 위치로 준비해놓고 싶어
    public float Interval = 5;


    private void Awake()
    {
        ir_CountDown = GameObject.Find("Timer").GetComponent<JIR_CountDown>();
        ir_startBtn = GameObject.Find("pCylinder96 3").GetComponent<JIR_TrainingStartBtn>();

    }

    private void Start()
    {
        itemList = ShuffleItems(itemList);

    }

    public static List<GameObject> ShuffleItems(List<GameObject> _items)
    {
        //items 리스트의 수만큼
        for(int i =0; i < _items.Count; i++)
        {
            GameObject temp = _items[i];
            int randomIndex = Random.Range(0, _items.Count);
            _items[i] = _items[randomIndex];
            _items[randomIndex] = temp;
        }
        return _items;
    }


    // Update is called once per frame
    void Update()
    {
        //// 대기시간이 2초 아래로 남았을 때 생성하도록 한다.
        //// createTime 시간도 있기 때문에
        if (ir_CountDown.totTime <= 2 && isClear == false)
        {
            CreateItem();
        }

    }
    
    /// <summary>
    /// Item 만드는 함수
    /// </summary>
    void CreateItem()
    {
        currentTime += Time.deltaTime;

        if (itemList.Count != 0)
        {
            if (currentTime > Interval)
            {
                currentTime = 0;

                Transform selectedPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject item = Instantiate(itemList[0], selectedPoint.transform.position, itemList[0].transform.rotation);
                itemList.RemoveAt(0);
                //int targetIndex = Random.Range(0, spawnPoints.Length);

                //for (int i = 0; i < itemList.Count; i++)
                //{
                //    if (prev != targetIndex)
                //    {
                //        itemIndex = itemList[0];

                //        Instantiate(itemIndex, spawnPoints[targetIndex].position, itemIndex.transform.rotation);
                //        itemList.RemoveAt(0);
                //    }
                //    prev = targetIndex;
                //}

            }
        }

        // 만약 아이템 리스트에 아이템이 없으면 5초 뒤에 아이템없다고 알리기
        if(itemList.Count == 0)
        {
            if(currentTime > stopWaitTime)
            {
                ir_startBtn.beltPlayer.Stop();
                isClear = true;
            }
        }

    }  

}
