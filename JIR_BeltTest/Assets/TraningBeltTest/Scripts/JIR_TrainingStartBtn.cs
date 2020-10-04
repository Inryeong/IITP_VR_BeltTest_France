using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @Function : 게임 시작 호출 함수
/// @Date : 2020-02-25
/// @History
///     2020-02-25 : 최초 작성
/// </summary>
/// 

public class JIR_TrainingStartBtn : MonoBehaviour
{

    public bool isTouch = false;            // 게임이 시작 여부
    Animator anim;                          // 버튼이 눌려졌을 때의 에니메이션

    public AudioSource beltPlayer;        // 버튼이 눌려졌을 때의 소리 재생기
    public AudioClip[] startAudioClip;      // 버튼이 눌려졌을 때의 소리와 컨베이어 Belt 작동 소리 파일


    public float beltSoundTimer = 1.0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        beltPlayer = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Contains("ControllerCollider"))
        {
            // 버튼이 눌러짐을 알림
            isTouch = true;

            beltPlayer.clip = startAudioClip[0];
            beltPlayer.loop = false;
            beltPlayer.PlayOneShot(startAudioClip[0], 1);

            MeshRenderer mr = GetComponent<MeshRenderer>();
            Material mat = mr.material;

            if (beltPlayer.isPlaying)
            {
                beltPlayer.clip = startAudioClip[1];
                beltPlayer.PlayDelayed(beltSoundTimer);
                beltPlayer.loop = true;
            }

            mat.color = Color.green;

            anim.SetBool("IsTouch", true);

            Destroy(gameObject.GetComponent<Collider>());

        }
    }

}
