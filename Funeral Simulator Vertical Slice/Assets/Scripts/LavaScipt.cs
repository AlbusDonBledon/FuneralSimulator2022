using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScipt : MonoBehaviour {

    [SerializeField]
    float waterLevel = 4;

    [SerializeField]
    float floatHeight = 2;

    [SerializeField]
    float bounceDamp = 0.05f;

    [SerializeField]
    Vector3 bouncyCenterOffset;

    [SerializeField]
    Rigidbody Car;

    private float forceFactor;
    private Vector3 actionPoint;
    private Vector3 upLift;
    private Vector3 stopLiftz;
    private Vector3 stopLiftx;


    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        actionPoint = transform.position + transform.TransformDirection(bouncyCenterOffset);
        forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        
        print("stop lift " + stopLiftz);

        if (forceFactor> 0f)
        {            
            upLift = -Physics.gravity * (forceFactor - Car.velocity.y * bounceDamp);
            Car.AddForceAtPosition(upLift, actionPoint);
       
            Car.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        }
		
	}
}
