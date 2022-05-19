using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGoUp : MonoBehaviour
{

    [SerializeField]
    Animator ElevatorGoesUpAnimator;

    [SerializeField]
    Animator DoorsR;

    [SerializeField]
    Animator DoorsL;

    [SerializeField]
    AudioSource ElevatorMusic;

    [SerializeField]
    AudioSource BGMusic;

    [SerializeField]
    AudioSource Bell;

    [SerializeField]
    Renderer Button1;
    [SerializeField]
    Light light1;

    [SerializeField]
    Renderer Button2;
    [SerializeField]
    Light light2;

    [SerializeField]
    Renderer Button3;
    [SerializeField]
    Light light3;

    [SerializeField]
    Renderer Button4;
    [SerializeField]
    Light light4;


    [SerializeField]
    Material Yellow;

    [SerializeField]
    Material Brown;

    [SerializeField]
    GameObject car;

    

    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


    }

    void OnTriggerEnter(Collider c_collider)
    {
       

        if (c_collider.gameObject == car)
        {
            MusicDown();
            ElevatorMusic.Play();

            

          ElevatorGoesUpAnimator.SetTrigger("CarIsIn");
            DoorsR.SetTrigger("CloseDoor");
            DoorsL.SetTrigger("CloseDoor");
            StartCoroutine(WaitToGoUp());
            StartCoroutine(SwitchSeconedButton());
            StartCoroutine(SwitchThirdButton());

        }

  
    }

    IEnumerator SwitchSeconedButton()
    { yield return new WaitForSeconds(2.5f);
        Button2.material = Yellow;
        Button1.material = Brown;
        light1.enabled = false;
        light2.enabled = true;
    }

    IEnumerator SwitchThirdButton()
    { yield return new WaitForSeconds(4.3f);
        Button3.material = Yellow;
        Button2.material = Brown;

        light2.enabled = false;
        light3.enabled = true;
    }

   

    IEnumerator WaitToGoUp()
    {
        
        yield return new WaitForSeconds(7);
        Button4.material = Yellow;
        Button3.material = Brown;

        light3.enabled = false;
        light4.enabled = true;

        Bell.Play();
        DoorsR.SetTrigger("OpenDoor");
        DoorsL.SetTrigger("OpenDoor");
        MusicUp();
    }

    void MusicDown()
    {
        while (BGMusic.spatialBlend != 1)
        {
            
            BGMusic.spatialBlend += 0.3f * Time.deltaTime;
            ElevatorMusic.spatialBlend -= 0.3f * Time.deltaTime;
        }
    }
    void MusicUp()
    {
        while (ElevatorMusic.spatialBlend != 1)
        {
            BGMusic.spatialBlend -=0.3f * Time.deltaTime;
            ElevatorMusic.spatialBlend += 0.3f * Time.deltaTime;
        }
    }

}
