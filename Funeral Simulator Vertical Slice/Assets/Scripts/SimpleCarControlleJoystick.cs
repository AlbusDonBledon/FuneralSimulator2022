using UnityEngine;
using System.Collections;
using System;
using Complete;


public class SimpleCarControllerJoystick : MonoBehaviour
{
    [SerializeField]
    float maxSteeringAngle = 45;

    [SerializeField]
    float maxMotorTorque = 400;

    [SerializeField]
    float maxSpeedinMPH = 10;

    [SerializeField]
    WheelCollider[] wheelsUsedForSteering;

    [SerializeField]
    WheelCollider[] wheelsUsedForDriving;

    [SerializeField]
    AnimationCurve torqueCurveModifier =
    new AnimationCurve(new Keyframe(0, 1), new Keyframe(20, 0.8f), new Keyframe(100, 0.3f));

    [SerializeField]
    WheelCollider[] allWheelColliders;

    [SerializeField]
    Transform[] allWheelModels;

    [SerializeField]
    AudioSource engine;

    [SerializeField]
    ParticleSystem ThrottleFlume;

    [SerializeField]
    WheelFrictionCurve WheeltoBreak;


    [SerializeField]
    float breakStiffness;

    [SerializeField]
    WheelCollider BreakWheel1;
    [SerializeField]
    WheelCollider BreakWheel2;

    [SerializeField]
    WheelCollider StandartWheel;






    public float currentSpeed;

    [SerializeField]
    float brakeTorque = 400;

    float driveInput;
    float steeringInput;
    Rigidbody rigidBody;

    [SerializeField]
    public GameObject[] inputButtons;
    private float ForwardVelocity
    {
        get
        {
            return transform.InverseTransformDirection(rigidBody.velocity).z;
        }

    }

    // Use this for initialization
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        this.rigidBody.centerOfMass = new Vector3(0.3f, 0.3f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {

            driveInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");
        }
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            driveInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");
        }
        /*
        if (Application.platform == RuntimePlatform.Android)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                //Do something with the touches
                if (myTouches[i].position == inputButtons[i].transform.position)
            }
        }
        */
        if (Application.platform == RuntimePlatform.Android)
        {

        }
    }
    public void moveLeft()
    {
        steeringInput = -1;
        // rigidBody.velocity = (maxSpeedinMPH / 2.23694f) *rigidBody.velocity.normalized;
        Debug.Log("Нажал кнопку");
    }
    public void moveUp()
    {
        driveInput = 1;
        Debug.Log("Нажал кнопку");
    }
    public void moveDawn()
    {
        driveInput = -1;
        Debug.Log("Нажал кнопку");
    }
    public void moveRight()
    {
        steeringInput = 1;
        Debug.Log("Нажал кнопку");
    }
    public void steeringStop()
    {
        steeringInput = 0;
        Debug.Log("Нажал кнопку");
    }
    public void moveStop()
    {
        driveInput = 0;
        Debug.Log("Нажал кнопку");
    }

    void FixedUpdate()
    {
        UpdateSteering();

        UpdateMotorTorque();

        UpdateBrakeTorque();

        UpdateWheelModels();

        //UpdateCameraVelocety();
    }

    private void UpdateWheelModels()
    {
        Vector3 positionToSet;
        Quaternion rotationToSet;

        for (int i = 0; i < allWheelModels.Length; i++)
        {

            allWheelColliders[i].GetWorldPose(out positionToSet, out rotationToSet);
            allWheelModels[i].position = positionToSet;
            allWheelModels[i].rotation = rotationToSet;
        }
    }

    private void UpdateBrakeTorque()
    {
        //Brakes?
        //when our forward velocity is one direction and our input if the opposite direction
        //apply the brakes

        bool carIsMovingSameDirectionAsInput = (ForwardVelocity > 0) == (driveInput > 0);

        float brakeTorqueToApply = 0;
        BreakWheel1.forwardFriction = StandartWheel.forwardFriction;
        BreakWheel2.forwardFriction = StandartWheel.forwardFriction;

        if (!carIsMovingSameDirectionAsInput && driveInput != 0)
        {
            brakeTorqueToApply = brakeTorque;

            WheeltoBreak.stiffness = breakStiffness; // Time.deltaTime;
            WheeltoBreak.asymptoteSlip = 0.8f;
            WheeltoBreak.asymptoteValue = 0.5f;
            WheeltoBreak.extremumSlip = 0.4f;
            WheeltoBreak.extremumValue = 1;


            BreakWheel1.forwardFriction = WheeltoBreak;
            BreakWheel2.forwardFriction = WheeltoBreak;
        }

        for (int i = 0; i < allWheelColliders.Length; i++)
        {
            allWheelColliders[i].brakeTorque = brakeTorqueToApply * 1000;
        }
    }

    private void UpdateMotorTorque()
    {
        for (int i = 0; i < wheelsUsedForDriving.Length; i++)
        {
            wheelsUsedForDriving[i].motorTorque =
                maxMotorTorque * driveInput *
                torqueCurveModifier.Evaluate(rigidBody.velocity.magnitude);
        }

        CapSpeed();
    }

    public void CapSpeed()
    {
        const float milesPerHourConst = 2.23694f;
        float speedInMPH = rigidBody.velocity.magnitude * milesPerHourConst;
        if (speedInMPH > maxSpeedinMPH)
        {
            rigidBody.velocity = (maxSpeedinMPH / milesPerHourConst) *
                rigidBody.velocity.normalized;
        }
        //Питч Звука зависит отскорости
        currentSpeed = speedInMPH;
        if (engine.pitch < 4) { engine.pitch = 1 + currentSpeed / 10; }
        if (engine.pitch > 4) { engine.pitch = 3.9f; }

        // Интенсивность партиклов завсисит от скорости
        ParticleSystem.EmissionModule emissionModuleRight;
        ParticleSystem.MainModule lifeTimeModule;

        emissionModuleRight = ThrottleFlume.emission;
        lifeTimeModule = ThrottleFlume.main;
        if (currentSpeed < 7) { emissionModuleRight.rateOverTime = 10f; }
        if (currentSpeed > 7) { emissionModuleRight.rateOverTime = 350f; }
        if (currentSpeed > 4) { lifeTimeModule.startLifetime = 0.25f; }
        if (currentSpeed > 20) { emissionModuleRight.rateOverTime = 620f; }
        if (currentSpeed > 20) { lifeTimeModule.startLifetime = 0.1f; }
    }



    private void UpdateSteering()
    {
        for (int i = 0; i < wheelsUsedForSteering.Length; i++)
        {
            wheelsUsedForSteering[i].steerAngle = maxSteeringAngle * steeringInput;
        }
    }
}
