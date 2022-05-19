using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class FlipDetector : MonoBehaviour {
    [SerializeField]
    private GameObject ground;

    [SerializeField]
    GameObject coffinStamp;

    [SerializeField]
    Canvas canvas;
    public bool flipped = false;

    [SerializeField]
    GameObject coffin;

    [SerializeField]
    private Grave m_Gravescrip;

    [SerializeField]
    string levelName;

    [SerializeField]
    Animator RestartButton;

    [SerializeField]
    AudioSource FailSound;

    float endTimeFailSound = 2.57f;


    
    AudioLowPassFilter backgroudMusicLowPassFilter;

    AudioHighPassFilter backgroudMusicHighPassFilter;


    // Use this for initialization
    void Start () {
        FailSound.gameObject.SetActive(false);
            
    }
    	
	// Update is called once per frame
	void Update () {
        backgroudMusicHighPassFilter = (AudioHighPassFilter)FindObjectOfType(typeof(AudioHighPassFilter));
        backgroudMusicLowPassFilter = (AudioLowPassFilter)FindObjectOfType(typeof(AudioLowPassFilter));
        if (Input.GetButtonDown("Restart"))
                { SceneManager.LoadScene(levelName);           
            backgroudMusicLowPassFilter.cutoffFrequency = 22000;
            backgroudMusicHighPassFilter.cutoffFrequency = 10;           
                }     
    }

    void OnTriggerEnter(Collider c_collider)
    {       
        if (c_collider.gameObject == ground)
        {
            StartCoroutine(FlipTimer());     
        }

    }

   void OnTriggerExit(Collider c_CoffinCollider)
    {
        if (c_CoffinCollider.gameObject == coffin)
            StartCoroutine(FlipTimer());       
    } 

    IEnumerator FlipTimer()
    {
        yield return new WaitForSeconds(1);

        if (m_Gravescrip.isDelivered == false)
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer)
                canvas.gameObject.SetActive(true);
            if (Application.platform == RuntimePlatform.WindowsEditor)
                canvas.gameObject.SetActive(true);
            if (Application.platform == RuntimePlatform.Android)
                canvas.gameObject.SetActive(true);
            RestartButton.SetTrigger("Crashed");          
         flipped = true;           
            print("played sound");
            backgroudMusicLowPassFilter.cutoffFrequency = Mathf.Lerp(22000f,1000f,3f);
            backgroudMusicHighPassFilter.cutoffFrequency = Mathf.Lerp(10f, 1000f, 3f);
            FailSound.gameObject.SetActive(true);
        }

    }
}
