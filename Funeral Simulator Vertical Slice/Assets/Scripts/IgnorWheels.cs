using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorWheels : MonoBehaviour {
    [SerializeField]
    Collider Streetcone;
    [SerializeField]
    Collider[] wheels;

    // Use this for initialization
    void Start ()
    {
        foreach (Collider wheels in wheels)
        { Physics.IgnoreCollision(Streetcone.GetComponent<Collider>(), wheels.GetComponent<Collider>()); }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
