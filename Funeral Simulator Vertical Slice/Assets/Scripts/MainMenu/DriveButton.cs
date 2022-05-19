using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;

public class DriveButton : MonoBehaviour
{

    [SerializeField]
    AudioSource BackGroundMusic;

    [SerializeField]
    GameObject Faq;

    [SerializeField]
    AudioSource GameMusic;
   [SerializeField]
    AudioSource BirdSound;

    [SerializeField]
    Canvas AndroidController;

    [SerializeField]
    Animator MainMenu;
    [SerializeField]
    GameObject DeactivateObject;
    [SerializeField]
    GameObject CameraRig;

    [SerializeField]
    Animator CameraAnimatro;

   [SerializeField] CameraControl camerControll;

    // Use this for initialization
    void Start()
    {
       camerControll.gameObject.GetComponent<CameraControl>();
        GameMusic.Pause();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchMenuToCredits()
    {
        CameraAnimatro.SetTrigger("MoveCamera");
        StartCoroutine("delayCoroutine");

        BackGroundMusic.enabled=false;
        BirdSound.enabled = false;

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidController.gameObject.SetActive(true);
        }

        GameMusic.volume = 0.209f;
        GameMusic.gameObject.SetActive(true);
        GameMusic.Play();
        Faq.gameObject.SetActive(true);

    }
    public IEnumerator delayCoroutine()
    {
        

        //  MainMenu.SetTrigger("Clicked");

        MoveCanvas();
       
        yield return new WaitForSeconds(0.9f);
        camerControll.IsInGame = true;
        DeactivateObject.SetActive(false);
    }

    private void MoveCanvas()
    {
        

        
       

            Vector3 strartLocalPosition = DeactivateObject.transform.position;
            Vector3 endLocalPosition = new Vector3(DeactivateObject.transform.position.x - 15, DeactivateObject.transform.position.y, DeactivateObject.transform.position.z);
            DeactivateObject.transform.localPosition = Vector3.Lerp(strartLocalPosition, endLocalPosition, Time.deltaTime);
        
        
        
    }
}
