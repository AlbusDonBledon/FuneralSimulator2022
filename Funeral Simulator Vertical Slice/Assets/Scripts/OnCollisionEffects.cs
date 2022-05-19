using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEffects : MonoBehaviour
{
    [SerializeField]
    Collider[] coffinColliders;

    [SerializeField]
    ParticleSystem crashEffect;
    [SerializeField]
    GameObject CarReference;

    [SerializeField]
    AudioSource carHitAudioSource;

    [SerializeField]
    AudioClip[] carHitSounds;
   
    Vector3 crashPoint;
    Quaternion crashRotation;

    // Use this for initialization
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {            
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider != coffinColliders[0] && other.collider != coffinColliders[1] && other.collider != coffinColliders[2] && other.collider != coffinColliders[3] && other.collider != coffinColliders[4] && other.collider != coffinColliders[5] && other.collider != coffinColliders[6])
        {
            
            //при соприкосновение не с гробом создает дым как детей машине         
            crashPoint = other.contacts[0].point;
            Quaternion sparclesDirection = CarReference.transform.rotation;
            var instance = Instantiate(crashEffect, crashPoint, sparclesDirection,CarReference.transform);

           int randomSound = Random.Range(0, 5);
            carHitAudioSource.clip = carHitSounds[randomSound];
            if (!carHitAudioSource.isPlaying)
                carHitAudioSource.Play();
            

            //C 50% вероятностью создает искры
            ParticleSystem.EmissionModule emissionModuleRight;
            emissionModuleRight = instance.emission;
            float chance = Random.value;           
            if (chance >= 0.5f)
            { emissionModuleRight.rateOverTime = 20f; }
            if (chance < 0.5f)
            { emissionModuleRight.rateOverTime = 0; }
        }
        

       
    }
}
