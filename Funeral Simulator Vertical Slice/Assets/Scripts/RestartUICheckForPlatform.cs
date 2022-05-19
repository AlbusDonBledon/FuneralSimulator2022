using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartUICheckForPlatform : MonoBehaviour {

    [SerializeField]
    Text textPC;

    [SerializeField]
    Text textMobile;

	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        { textPC.gameObject.SetActive(true); }

        if (Application.platform == RuntimePlatform.WindowsEditor)
        { textPC.gameObject.SetActive(true); }

        if (Application.platform == RuntimePlatform.OSXPlayer)
        { textPC.gameObject.SetActive(true); }

        if (Application.platform == RuntimePlatform.Android)
        { textMobile.gameObject.SetActive(true); }

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        { textMobile.gameObject.SetActive(true); }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
