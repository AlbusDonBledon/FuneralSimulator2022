using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour {
    [SerializeField]
    Animator text;

        [SerializeField]
    Animator bg;

        [SerializeField]
    Animator spark;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("L"))
        {
            text.SetTrigger("New Trigger");
            bg.ResetTrigger("New Trigger");
            spark.ResetTrigger("New Trigger");
        }




    }
}
