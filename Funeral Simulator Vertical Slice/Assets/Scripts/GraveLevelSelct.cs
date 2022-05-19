using UnityEngine;
using System.Collections;
using Complete;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveLevelS : MonoBehaviour {

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
    AudioSource StampSound;

    [SerializeField]
    AudioSource PaperSound;

    [SerializeField]
    Light RedLight;

    bool carIn = false;

    private CameraControl m_CameraControl;

    float DampDecresmentRate;
    public bool isDelivered = false;

    public int currentLevel;

    // Use this for initialization
    void Start () {

        m_CameraControl = CameraRig.GetComponent<CameraControl>();

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
            SetCameraToNewTarget();
            cancvas.gameObject.SetActive(true);
            CoffinStampImage.gameObject.SetActive(false);
            ClientStampImage.gameObject.SetActive(false);
            CarStampImage.gameObject.SetActive(false);
            isDelivered = true;
            SclollUnwrap();  
            //Отркываем новые уровни
            PlayerPrefs.SetInt("pointsCoffin" + currentLevel.ToString(), 1);
        }
        if (c_collider.gameObject == body)
        {
            print("body in");
            if (!PlayerPrefs.HasKey("pointsBody" + currentLevel.ToString()))
            {
                PlayerPrefs.SetInt("pointsBody" + currentLevel.ToString(), 1);
            }
           // PlayerPrefs.SetInt("pointsBody" + currentLevel.ToString(), 1);

            StartCoroutine(ClientStampRoutine());
            
       }
        if (c_collider.gameObject == car)
        {
            carIn = true;
            print("car in");
            CarStampImage.gameObject.SetActive(false);
        }
    }
    private void SetCameraToNewTarget()
    {
        
        // Create a collection of transforms the same size as the number of tanks.
        Transform[] targets = new Transform[m_CameraControl.m_Targets.Length];

        m_CameraControl.m_Targets = Cofin;

        float DampRate = (-1 * Time.deltaTime);

        m_CameraControl.Zoom();

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
        yield return new WaitForSeconds(1);

        CoffinStampImage.gameObject.SetActive(true);
        CoffinStamp.SetTrigger("Stamp");
        StampSound.Play();

    }

    IEnumerator ClientStampRoutine()
    {
        
          
        
        yield return new WaitForSeconds(1.2f);

        ClientStampImage.gameObject.SetActive(true);
        ClientStamp.SetTrigger("Stamp");
        StampSound.Play();
        RedLight.range = 1005;



    }

    IEnumerator CarStampRoutine()
    {
        yield return new WaitForSeconds(1.3f);

        CarStampImage.gameObject.SetActive(true);
        CarStamp.SetTrigger("Stamp");
        StampSound.Play();
        //засчитали очки
        PlayerPrefs.SetInt("pointsCarless" + currentLevel.ToString(), 1);

    }



}

