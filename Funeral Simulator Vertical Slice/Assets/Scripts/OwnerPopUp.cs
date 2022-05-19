using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OwnerPopUp : MonoBehaviour {

    [SerializeField]
    Animator PopUPAnimator;

    [SerializeField]
    GameObject ownnerCanvas;

    [SerializeField]
    Text numOfRetrys;

    // Use this for initialization
    void Start()
    {
        { PopUPCharacter(); }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PopUPCharacter()
    {
        if (int.Parse(numOfRetrys.text) > 1)
        { ownnerCanvas.SetActive(false); }

        PopUPAnimator.SetTrigger("PopUP");
        //зачем если все равно его не везде ставить?
        //if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 4)
        //    { PopUPAnimator.SetTrigger("PopUP"); }
        
    }
}
