using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
        //  Screen.lockCursor = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
