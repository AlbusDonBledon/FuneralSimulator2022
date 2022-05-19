using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {

    [SerializeField]
    Animator MainMenu;
    [SerializeField]
    Animator Camera;
    [SerializeField]
    Animator Credits;
    [SerializeField]
    GameObject ActivateObject;
    [SerializeField]
    GameObject DeactivateObject;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void SwitchMenuToCredits()
    {
        StartCoroutine("delayCoroutine");
    }
   public IEnumerator delayCoroutine()
    {
        ActivateObject.SetActive(true);
        MainMenu.SetTrigger("Clicked");
        Credits.SetTrigger("Clicked1");
        Camera.SetTrigger("Clicked");
        yield return new WaitForSeconds(1.1f);
        DeactivateObject.SetActive(false);
    }
}

