using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinHitSounds : MonoBehaviour {

    [SerializeField]
    AudioSource coffinHitAudioSource;

    [SerializeField]
    AudioClip[] coffinHitSounds;

    [SerializeField]
    Collider coffinCollider;

    [SerializeField]
    Collider carCollider;

    [SerializeField]
    Collider bodyCollider;

    [SerializeField]
    Collider coffinLidCollider;


    // Use this for initialization
    void Start () {   

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    { if (other.collider != carCollider && other.collider != bodyCollider && other.collider != coffinLidCollider)
        {          
            int randomSound = Random.Range(0, 5);
            coffinHitAudioSource.clip = coffinHitSounds[randomSound];
            if (!coffinHitAudioSource.isPlaying)
            { coffinHitAudioSource.Play(); }
        }
    }

}
