using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

    [SerializeField]
    GameObject car;

    [SerializeField]
    WheelCollider DriftWheel1;

    [SerializeField]
    WheelCollider DriftWheel2;

    [SerializeField]
    WheelCollider DriftWheel3;

    [SerializeField]
    WheelCollider DriftWheel4;


    [SerializeField]
    WheelCollider StandartWheel;

    [SerializeField]
    WheelFrictionCurve WheeltoDrift;

    WheelFrictionCurve WheeltoNormal;

    [SerializeField]
    float DriftStiffness = 0.5f;

    [SerializeField]
    float NormanlFriction = 1f;

   public bool isOnice = false;

    // Use this for initialization
    void Start() {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isOnice == false)
        {
            DriftWheel1.sidewaysFriction = StandartWheel.sidewaysFriction;
            DriftWheel2.sidewaysFriction = StandartWheel.sidewaysFriction;
            DriftWheel3.sidewaysFriction = StandartWheel.sidewaysFriction;
            DriftWheel4.sidewaysFriction = StandartWheel.sidewaysFriction;
        }

    }


    void OnTriggerStay(Collider c_collider)
    {
       

        if (c_collider.gameObject == car)
        {
            isOnice = true;
            //  Drifting drifting = GetComponent<Drifting>();
            //  drifting.isDrifting = true;
            //  drifting.Slide();

            print("sliding");
            WheeltoDrift.stiffness = DriftStiffness * Time.deltaTime;


            DriftWheel1.sidewaysFriction = WheeltoDrift;
            DriftWheel2.sidewaysFriction = WheeltoDrift;
            DriftWheel3.sidewaysFriction = WheeltoDrift;
            DriftWheel4.sidewaysFriction = WheeltoDrift;

        }

    }

    void OnTriggerExit (Collider c_collider)
    {
        

        if (c_collider.gameObject == car)
        {
            print("off the pudle");
            isOnice = false;
        }

    }

}


