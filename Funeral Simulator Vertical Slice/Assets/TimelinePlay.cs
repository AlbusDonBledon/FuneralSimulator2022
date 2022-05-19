using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
	

public class TimelinePlay : MonoBehaviour {

    [SerializeField]
    GameObject TimelineHolder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayTimeline()
    {
        PlayableDirector pd = TimelineHolder.GetComponent<PlayableDirector>();
        if(pd != null )
        { pd.Play();}
    }
}
