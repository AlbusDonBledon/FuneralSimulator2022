using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

    [SerializeField]
    Animator MainMenu;
    [SerializeField]
    Animator Credits;
    [SerializeField]
    GameObject ActivateObject;
    [SerializeField]
    GameObject DeactivateObject;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchMenuToCredits()
    {
        StartCoroutine("delayCoroutine");
    }
    public IEnumerator delayCoroutine()
    {
        ActivateObject.SetActive(true);
        MainMenu.SetTrigger("ClickedBack");
        Credits.SetTrigger("Clicked2");
        yield return new WaitForSeconds(1.1f);
        DeactivateObject.SetActive(false);
    }
}
