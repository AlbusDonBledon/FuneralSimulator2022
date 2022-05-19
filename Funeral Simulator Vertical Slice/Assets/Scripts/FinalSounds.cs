using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSounds : MonoBehaviour {

    [SerializeField] GameObject coffin;

    [SerializeField]
    AudioSource FinalSound;

    [SerializeField]
    AudioSource DrumRoll;

    [SerializeField]
    AudioSource Applouse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider c_collider)
    {
        if (c_collider.gameObject == coffin)
        {
            FinalSound.Play();
            DrumRoll.Pause();
            Applouse.Play();
        }
    }

}
