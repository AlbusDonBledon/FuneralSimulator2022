using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMarks : MonoBehaviour {
    [SerializeField]
    GameObject skidMark;

    [SerializeField]
    GameObject wheel;

    [SerializeField]
    GameObject parentino;

    [SerializeField]
    GameObject parentino2;

    bool isDrifting;

   List<GameObject> instansesOfTheDrift;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        wheel.GetComponent<Transform>();

        parentino2.transform.position = wheel.transform.position;

        if (Input.GetButtonDown("Drift"))
        {
            isDrifting = true;

            SpawnSkid();

        }

        if (Input.GetKeyUp("space"))
        {
            
            isDrifting = false;
        }


        if(isDrifting==false)
        {
            parentino2.transform.DetachChildren();
        }
    }

    void SpawnSkid()
    {
        GameObject driftInctance =
                Instantiate(skidMark, parentino.transform.parent) as GameObject;
    }
}
