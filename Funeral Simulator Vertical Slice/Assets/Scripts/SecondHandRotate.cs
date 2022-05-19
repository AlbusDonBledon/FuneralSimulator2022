using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecondHandRotate : MonoBehaviour
{

    [SerializeField]
    GameObject secondImage;

    float smooth = 15;
    float tiltAngle = -181;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiltAngle = tiltAngle - 1;
        RotateHand();
    }

    void RotateHand()
    {
        Quaternion target = Quaternion.Euler(0, 0, tiltAngle);
        secondImage.transform.rotation = Quaternion.Slerp(secondImage.transform.rotation, target, Time.deltaTime * smooth);
    }
}
