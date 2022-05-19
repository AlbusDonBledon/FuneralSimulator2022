using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivateUISelectLevel : NewLevelSelect
{

  //  public GameObject UISelect;
    //public GameObject SelectCanvas;
    // Use this for initialization
    void Start () {
        //StartCoroutine( Wait());


    }
    IEnumerator Wait()
    {
        print("Waiting");
        yield return new WaitForSeconds(3);
        UISelect.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        /*    if (SelectCanvas.activeSelf == true)
                UISelect.SetActive(true);
            else
                UISelect.SetActive(false);*/
        
    }
}
