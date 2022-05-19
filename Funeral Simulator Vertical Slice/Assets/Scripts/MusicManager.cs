using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour {
    [SerializeField]
    AudioSource BackgroundMusic;

    float musicAtMin;

        private static AudioSource _instance;

    void Awake()
    {
        SetSoundInstance();
    }

    void Update()
    {
       

        if (Input.GetButtonDown("Restart"))
        {           
            musicAtMin = BackgroundMusic.time;
        }
    }

    void SetSoundInstance()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = BackgroundMusic;


        //otherwise, if we do, kill this thing
        else
            Destroy(BackgroundMusic.gameObject);

        DontDestroyOnLoad(BackgroundMusic.gameObject);
        BackgroundMusic.PlayScheduled(musicAtMin);
    }
}



