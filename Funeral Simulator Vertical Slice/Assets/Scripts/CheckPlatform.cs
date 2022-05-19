using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour {

    // Use this for initialization
    GameObject androidController;
    GameObject FAQ;
	void Start () {

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            androidController = GameObject.Find("AndroidController");
            androidController.gameObject.SetActive(false);
            FAQ = GameObject.Find("FAQ");
           // FAQ.gameObject.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            androidController = GameObject.Find("AndroidController");
            androidController.gameObject.SetActive(false);
            FAQ = GameObject.Find("FAQ");
            FAQ.gameObject.SetActive(true);
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
