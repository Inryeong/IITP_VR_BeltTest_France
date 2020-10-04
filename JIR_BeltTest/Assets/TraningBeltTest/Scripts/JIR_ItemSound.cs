using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JIR_ItemSound : MonoBehaviour
{
    // - 만약 TrashBin이라는 이름이 포함되는 곳에 닿았다면 Sound 재생

    // - 오디오클립
    public AudioSource audioPlayer;
    public AudioClip audioClip;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("TrashBin"))
        {
            audioPlayer.PlayOneShot(audioClip);
        }
    }
}
