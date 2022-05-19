using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class AnimatorTriggerSet : MonoBehaviour {

    [SerializeField]
    Animator AnimatorTrigger;

    [SerializeField]
    string TriggerName;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

   public void SetAnimationTrigger()
    {
        AnimatorTrigger.SetTrigger(TriggerName);
    }
}
