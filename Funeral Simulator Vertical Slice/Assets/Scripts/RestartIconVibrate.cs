using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartIconVibrate : MonoBehaviour

{
    [SerializeField]
    GameObject restartIcon;

    float scaleFactor = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IndicareRestart();
    }

    void IndicareRestart()
    {
        if(Input.GetKey("r"))
        {
            restartIcon.transform.localScale = new Vector3(1.44f*scaleFactor,0.8f*scaleFactor,0.8f*scaleFactor);
        }
    }
}
