using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScroll : MonoBehaviour {
    [SerializeField]
    Image OverGraveScroll;

    [SerializeField]
    Collider Car;


    float min = 0;
    float max = 1;
    float time = 0.1f;


	// Use this for initialization
	void Start () {

        
        OverGraveScroll.transform.localScale = new Vector3(0, 0, 0);
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (OverGraveScroll.transform.localScale != new Vector3(0, 0, 0))
        { OverGraveScroll.transform.localScale -= new Vector3(Mathf.Lerp(min, max, time), Mathf.Lerp(min, max, time), Mathf.Lerp(min, max, time)); }

    }

    void OnTriggerStay(Collider c_Car)
    {
        

        if ((OverGraveScroll.transform.localScale != new Vector3(max, max, max)) && (c_Car == Car))
        { OverGraveScroll.transform.localScale += new Vector3(Mathf.Lerp(min, max, time), Mathf.Lerp(min, max, time), Mathf.Lerp(min, max, time)); }
      
    }

    void OnTriggerLeave(Collider c_Car)
    {
        c_Car = Car;
        if ((OverGraveScroll.transform.localScale != new Vector3(0, 0, 0)) && (c_Car == Car))
        { OverGraveScroll.transform.localScale -= new Vector3(Mathf.Lerp(min, max, time), Mathf.Lerp(min, max, time), Mathf.Lerp(min, max, time)); }
    }


    }
