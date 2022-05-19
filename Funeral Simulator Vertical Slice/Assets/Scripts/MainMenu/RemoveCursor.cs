using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCursor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

     
    }

   public void RemoveCursore()
    {
        Cursor.visible = false;
        //  Screen.lockCursor = true;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
	
