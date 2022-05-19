using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    [SerializeField]
    Canvas pauseMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


      //  Pause();

        if (Input.GetButtonDown("pause"))
        { Pause(); }

    }

   public void Pause()
    {

       
        
            // print("paused");

            if (Time.timeScale == 1)
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
            // print("paused");
              Cursor.visible = true;
            //  Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.Confined;
           }
            else
            {
            Cursor.visible = false;
            //  Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
          
        }
        
    }
}
