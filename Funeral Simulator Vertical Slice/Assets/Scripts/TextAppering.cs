using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextAppering : MonoBehaviour {

    [SerializeField]
    float delay;

    private
    int numberOfTextBlocks = 0;

    [SerializeField]
    string[] fullText;

    [SerializeField]
    Animator OwnerAnimator;

    [SerializeField]
    GameObject TrueCar;

    [SerializeField]
    Text numOfRetrys;

    private string currentText = "";

    // Use this for initialization
    void Start() {
        StartCoroutine(ShowText()); TakeControlAway();
        if (int.Parse(numOfRetrys.text) > 1) { GiveControlBack(); }
        
        
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("space") && (currentText.Length == fullText[numberOfTextBlocks].Length))
        {
            numberOfTextBlocks++;
            StartCoroutine(ShowText());
        }

        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("space"))
        {
            delay = 0.01f;

        }

        if (Input.GetKeyUp("joystick button 0") || Input.GetKeyUp("space"))
        {
            delay = 0.05f;
        }

        if (fullText.Length == numberOfTextBlocks)
        {
            if (Input.GetKey("joystick button 0") || Input.GetKey("space"))
            { OwnerAnimator.SetTrigger("PopDown");GiveControlBack(); }
            if (SceneManager.GetActiveScene().buildIndex == 5 && Input.GetKey("joystick button 3"))
            {
                SceneManager.LoadScene(1);
            }
        }

    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText[numberOfTextBlocks].Length; i++)
        {
            currentText = fullText[numberOfTextBlocks].Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }

    void TakeControlAway()
    {
        TrueCar.GetComponent<SimpleCarController>().enabled = false;
        TrueCar.GetComponent<Drifting>().enabled = false;
    }
    void GiveControlBack()
    {
        TrueCar.GetComponent<SimpleCarController>().enabled = true;
        TrueCar.GetComponent<Drifting>().enabled = true;
    }
}
