using UnityEngine;
using System.Collections;
using Complete;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Grave : MonoBehaviour {

    [SerializeField]
    Transform [] Cofin;

    [SerializeField]
    GameObject coffin;

    [SerializeField]
    GameObject body;

    [SerializeField]
    GameObject car;

    [SerializeField]
    GameObject CameraRig;

    [SerializeField]
    Canvas cancvas;

    [SerializeField]
    Image scrollImage;

    [SerializeField]
    Animator ScrollinAnimator;

    [SerializeField]
    Animator NextButton;

    [SerializeField]
    Animator RestartButton;

    [SerializeField]
    Animator ClientStamp;
    [SerializeField]
    Animator CoffinStamp;
    [SerializeField]
    Animator CarStamp;

    [SerializeField]
    Image CoffinStampImage;

    [SerializeField]
    Image ClientStampImage;

    [SerializeField]
    Image CarStampImage;

    [SerializeField]
    Sprite unCarStampImage;

    [SerializeField]
    Sprite unClientStampImage;

    [SerializeField]
    AudioSource StampSound;

    [SerializeField]
    AudioSource PaperSound;

    [SerializeField]
    AudioSource marchSound;

    [SerializeField]
    AudioSource bellSound;

    [SerializeField]
    AudioSource SuccessSound;

    [SerializeField]
    Light RedLight;

    [SerializeField]
    int LevelToLoad;

    AudioLowPassFilter backgroudMusicLowPassFilter;

    AudioHighPassFilter backgroudMusicHighPassFilter;

    int x = 0; //что это?

    bool carIn = false;

    private CameraControl m_CameraControl;

    float DampDecresmentRate;
    public bool isDelivered = false;

    public int currentLevel;

    // Use this for initialization
    void Start () {

        m_CameraControl = CameraRig.GetComponent<CameraControl>();

        x = SceneManager.GetActiveScene().buildIndex;

        //  m_CameraControl.transform = Cofin.transform;
        // currentLevel = Application.loadedLevelName;

       
    }
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter(Collider c_collider)
    {
       


        if (c_collider.gameObject == coffin)
        {
            if (x == 100)
            {
                SceneManager.LoadScene(LevelToLoad);
            }
            if (x != 0)
            {
                backgroudMusicHighPassFilter = (AudioHighPassFilter)FindObjectOfType(typeof(AudioHighPassFilter));
                backgroudMusicLowPassFilter = (AudioLowPassFilter)FindObjectOfType(typeof(AudioLowPassFilter));
                SetCameraToNewTarget();
                cancvas.gameObject.SetActive(true);
                CoffinStampImage.gameObject.SetActive(false);
                ClientStampImage.gameObject.SetActive(false);
                CarStampImage.gameObject.SetActive(false);
                isDelivered = true;
                SclollUnwrap();
                //Отркываем новые уровни
                PlayerPrefs.SetInt("pointsCoffin" + currentLevel.ToString(), 1);
                StartCoroutine(ClientStampRoutine());
               // StartCoroutine(CarStampRoutine());
                backgroudMusicLowPassFilter.cutoffFrequency = Mathf.Lerp(22000f, 1000f, 3f);
                backgroudMusicHighPassFilter.cutoffFrequency = Mathf.Lerp(10f, 1000f, 3f);
            }
        }
        if (c_collider.gameObject == body)
        {
            if (x != 1)
            {
                print("body in");
                if (!PlayerPrefs.HasKey("pointsBody" + currentLevel.ToString()))
                {
                    PlayerPrefs.SetInt("pointsBody" + currentLevel.ToString(), 1);
                }
                // PlayerPrefs.SetInt("pointsBody" + currentLevel.ToString(), 1);

               // ClientStampImage.sprite = unClientStampImage;
                StartCoroutine(ClientStampRoutine());
               // StartCoroutine(CarStampRoutine());
            }
       }
        if (c_collider.gameObject == car)
        {
            if (x != 0)
            {
                carIn = true;
                print("car in");
                CarStampImage.gameObject.SetActive(false);               
               // CarStampImage.sprite = unCarStampImage;
               // StartCoroutine(CarStampRoutine());
            }
        }
    }
    private void SetCameraToNewTarget()
    {
        
        // Create a collection of transforms the same size as the number of tanks.
        Transform[] targets = new Transform[m_CameraControl.m_Targets.Length];

        m_CameraControl.m_Targets = Cofin;

        float DampRate = (-1 * Time.deltaTime);
        if (m_CameraControl.m_Camera.fieldOfView > 15)
        {
            m_CameraControl.Zoom();
            m_CameraControl.m_Camera.fieldOfView = 15;


        }

        

        StartCoroutine(ChangeDampTime());

       // m_CameraControl.m_DampTime = Mathf.Lerp(0.2f, 0.01f, Time.deltaTime);

    
        // ... set it to the appropriate tank transform.
        //targets[0] = Cofin.transform;

        m_CameraControl.m_Targets[0] = Cofin[0];

        // These are the targets the camera should follow.
        m_CameraControl.target = targets[0];

        int i = 2;

        if ( i < targets.Length)
        {
            i = 1;
        }


    }

    void SclollUnwrap()
    {

        ScrollinAnimator.SetTrigger("Deliver");
        NextButton.SetTrigger("OnScroll");
        RestartButton.SetTrigger("OnScroll");

        StartCoroutine(CoffinStampRoutine());

        PaperSound.Play();
        bellSound.Play();
        SuccessSound.Play();
        marchSound.Play();
       
        if (carIn == false)
        {   
            StartCoroutine(CarStampRoutine());     
        }
    }

    IEnumerator ChangeDampTime()
    {
        float elapsetime = 0;
        float timer= 0.5f;
        while (elapsetime < timer)
        {
            m_CameraControl.m_DampTime = Mathf.Lerp(0.2f, 0.01f, elapsetime/timer);

            elapsetime += Time.deltaTime;

            yield return new WaitForEndOfFrame();

        }

    }

    IEnumerator CoffinStampRoutine()
    {
        yield return new WaitForSeconds(1.3f);

        CoffinStampImage.gameObject.SetActive(true);
        CoffinStamp.SetTrigger("Stamp");
        StampSound.Play();

    }

    IEnumerator ClientStampRoutine()
    {
        
          
        
        yield return new WaitForSeconds(1.4f);

        ClientStampImage.gameObject.SetActive(true);
        ClientStamp.SetTrigger("Stamp");
        StampSound.Play();
      //  RedLight.range = 1005;



    }

    IEnumerator CarStampRoutine()
    {
        yield return new WaitForSeconds(1.7f);

        CarStampImage.gameObject.SetActive(true);
        CarStamp.SetTrigger("Stamp");
        StampSound.Play();
        //засчитали очки
        PlayerPrefs.SetInt("pointsCarless" + currentLevel.ToString(), 1);

    }



}

