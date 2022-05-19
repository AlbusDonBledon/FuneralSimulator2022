using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {

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
            bg.SetTrigger("New Trigger");
            spark.SetTrigger("New Trigger");
            print("pressed");

        }


    }
}
