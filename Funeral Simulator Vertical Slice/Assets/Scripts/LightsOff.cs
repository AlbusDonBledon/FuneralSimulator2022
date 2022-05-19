using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : MonoBehaviour {

    public GameObject Lights1;
    public GameObject Lights2;
    public GameObject car;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider c_collider)
    {
        if (c_collider.gameObject == car)
        {
            Lights1.SetActive(false);
            Lights2.SetActive(false);
        }

    }
}
