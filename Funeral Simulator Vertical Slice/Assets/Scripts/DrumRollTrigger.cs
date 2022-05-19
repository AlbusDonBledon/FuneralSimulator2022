using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumRollTrigger : MonoBehaviour {
   [SerializeField] GameObject DrumRoll;

    [SerializeField]
    AudioSource BackgroundMusic;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    { DrumRoll.SetActive(true);
        BackgroundMusic.volume = Mathf.Lerp(0.2f, 0.001f, 0.1f);
    }
}
