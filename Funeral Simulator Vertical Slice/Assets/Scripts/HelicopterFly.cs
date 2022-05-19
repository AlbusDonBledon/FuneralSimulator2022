using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterFly : MonoBehaviour {


    [SerializeField]
    Animator flyAwayAnimator;

    [SerializeField]
    GameObject coffin;

    [SerializeField]
    Collider graveTrigger;

    
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       

       

    }

    void OnTriggerEnter(Collider graveTrigger)
    {
        //graveTrigger = graveTriggerW;

        if (graveTrigger.gameObject == coffin)
        {

            print("GEttin' OUT from here bois");
            flyAwayAnimator.SetTrigger("Deliver");
        }

    }
}
