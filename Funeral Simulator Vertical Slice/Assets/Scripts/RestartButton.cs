using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class RestartButton : MonoBehaviour {

    [SerializeField]
    Canvas AndroidController;

    int currentScene;

    AudioLowPassFilter backgroudMusicLowPassFilter;

    AudioHighPassFilter backgroudMusicHighPassFilter;
   
    public void LoadByIndex(int sceneIndex)
    {
        backgroudMusicHighPassFilter = (AudioHighPassFilter)FindObjectOfType(typeof(AudioHighPassFilter));
        backgroudMusicLowPassFilter = (AudioLowPassFilter)FindObjectOfType(typeof(AudioLowPassFilter));

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        { AndroidController.gameObject.SetActive(false); }

        if (Application.platform == RuntimePlatform.Android)
        { AndroidController.gameObject.SetActive(true); }

        if (Time.timeScale == 0)
        { Time.timeScale = 1; }
        SceneManager.LoadScene(sceneIndex);

        backgroudMusicLowPassFilter.cutoffFrequency = 22000;
        backgroudMusicHighPassFilter.cutoffFrequency = 10;
        
    }
}
