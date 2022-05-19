using UnityEngine;
using System.Collections;

public class Drifting : MonoBehaviour
{    
    [SerializeField]
    WheelCollider DriftWheel1;

    [SerializeField]
    WheelCollider DriftWheel2;

    [SerializeField]
    WheelCollider DriftWheel3;

    [SerializeField]
    WheelCollider DriftWheel4;

    [SerializeField]
    GameObject Level;

    [SerializeField]
    WheelCollider StandartWheel;

    [SerializeField]
    WheelFrictionCurve WheeltoDrift;

    [SerializeField]
    TrailRenderer DriftSkirt;

    [SerializeField]
    AudioSource driftSound;

    WheelFrictionCurve WheeltoNormal;

    [SerializeField]
    float DriftStiffness;

    [SerializeField]
    Transform backWeelRPosition;

    [SerializeField]
    GameObject trueCar;
    SimpleCarController m_SimpleCarController;

    [SerializeField]
    float NormanlFriction = 1f;

    [SerializeField]
    ParticleSystem DriftSmokeLeft;
    [SerializeField]
    ParticleSystem DriftSmokeRight;

    [SerializeField]
    Transform driftMarkSpawnPositionRight;
    [SerializeField]
    Transform driftMarkSpawnPositionLeft;

    float startSegmentTimeline = 0;
   [SerializeField]
    float firstSegmentTimeline = 0.5f;
    [SerializeField]
    float secondSegmentTimeline = 1.1f;
    float endSegmentTimeline = 2.232f;

    public bool isDrifting = false;


    // Use this for initialization
    void Start()
    {
        m_SimpleCarController = trueCar.GetComponent<SimpleCarController>();
    }

    // Update is called once per frame
    void Update()

    {
        Ice ice = GameObject.Find("IceTrigger").GetComponent<Ice>();
        isDrifting = ice.isOnice;

        // stabaliseVriction();
       // print(driftSound.time);
        if (driftSound.time > secondSegmentTimeline && isDrifting) // если дальше черты зациклить в отрывке
        {
            driftSound.loop = true;
            driftSound.SetScheduledStartTime(driftSound.time = firstSegmentTimeline);
        }


        if (ice.isOnice==false)
        {
            DriftWheel1.sidewaysFriction = StandartWheel.sidewaysFriction;
            DriftWheel2.sidewaysFriction = StandartWheel.sidewaysFriction;
            DriftWheel3.sidewaysFriction = StandartWheel.sidewaysFriction;
            DriftWheel4.sidewaysFriction = StandartWheel.sidewaysFriction;
            UnchildSwpawnPoints();          
        }

        if (Input.GetButton("Drift"))
        {
            ice.isOnice = true;

            WheeltoDrift.stiffness = DriftStiffness; // Time.deltaTime;

            WheeltoDrift.asymptoteSlip = 0.8f;
            WheeltoDrift.asymptoteValue = 0.5f;
            WheeltoDrift.extremumSlip = 0.4f;
            WheeltoDrift.extremumValue = 1;


            DriftWheel1.sidewaysFriction = WheeltoDrift;
            DriftWheel2.sidewaysFriction = WheeltoDrift;
            }

        if (Input.GetButtonDown("Drift") || Input.GetKeyDown("joystick button 0"))
        {
            DriftMarksSpawn();
 
            //  driftSound.Play();  
           // driftSound.SetScheduledEndTime(secondSegmentTimeline);
            driftSound.PlayScheduled(driftSound.time); //играть звук дрифта сначала

          
        }
         
        if (Input.GetKeyUp("space") || Input.GetKeyUp("joystick button 0"))
            ice.isOnice = false;
        //дым от дрифта плавно появляется когда дрифтуешь
        ParticleSystem.EmissionModule driftCloudRight;
        ParticleSystem.EmissionModule driftCloudLeft;
        driftCloudRight = DriftSmokeRight.emission;
        driftCloudLeft = DriftSmokeLeft.emission;
        //добавить когда только на земле и не перевернут(!!!)
        if (ice.isOnice == true) { driftCloudRight.rateOverTime = 60f; }
         else { driftCloudRight.rateOverTime = 0; }
        if (ice.isOnice == true) { driftCloudLeft.rateOverTime = 60f;}
        else { driftCloudLeft.rateOverTime = 0; }

        driftSound.loop = false;
       // driftSound.SetScheduledStartTime(secondSegmentTimeline);
        

    }

    void stabaliseVriction()
    {
        WheeltoNormal.stiffness = NormanlFriction;

        DriftWheel1.sidewaysFriction = WheeltoNormal;
        DriftWheel2.sidewaysFriction = WheeltoNormal;
        print("not drifting");
    }


    public void Drift()
    {
        Ice ice = GameObject.Find("IceTrigger").GetComponent<Ice>();

        ice.isOnice = true;

        WheeltoDrift.stiffness = DriftStiffness * Time.deltaTime;


        DriftWheel1.sidewaysFriction = WheeltoDrift;
        DriftWheel2.sidewaysFriction = WheeltoDrift;
    }

    public void notDrift()
    {
        Ice ice = GameObject.Find("IceTrigger").GetComponent<Ice>();

        ice.isOnice = false;
    }

         void DriftMarksSpawn() //спавним марки от дрифта
    {       
        TrailRenderer markInstanceRight = Instantiate(DriftSkirt,driftMarkSpawnPositionRight.position, driftMarkSpawnPositionRight.rotation,driftMarkSpawnPositionRight) as TrailRenderer;
        TrailRenderer markInstanceLeft = Instantiate(DriftSkirt, driftMarkSpawnPositionLeft.position, driftMarkSpawnPositionLeft.rotation, driftMarkSpawnPositionLeft) as TrailRenderer;
    }


    void UnchildSwpawnPoints() //что бы марки сначала след за колесом потом отвалились
    {
        var clonecheckRight = driftMarkSpawnPositionRight.childCount; //проверить есть ли уже там след
        if (clonecheckRight > 0)
        {
            var driftmarkclone = driftMarkSpawnPositionRight.GetChild(0); //если нет то взять первый и заанперентить его
            driftmarkclone.transform.parent = null;
        }

        var clonecheckLeft = driftMarkSpawnPositionLeft.childCount; //тоже самое для левого колеса
        if (clonecheckLeft > 0)
        {
            var driftmarkclone = driftMarkSpawnPositionLeft.GetChild(0);
            driftmarkclone.transform.parent = null;
        }
    }

}

