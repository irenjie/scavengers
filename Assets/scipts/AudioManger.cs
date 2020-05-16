using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;


//播放音乐音效
public class AudioManger : MonoBehaviour
{
    public static AudioManger instance { get; private set; }

    private AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioPlay(AudioClip clip) {
        audioS.PlayOneShot(clip);
    }
}
