using UnityEngine;
using System.Collections;

public class SlowMo : MonoBehaviour
{

    [SerializeField]
    GameObject car;

    [SerializeField]
    float slowmo;

    bool isSlowmo = false ;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(isSlowmo == false)
            { Time.timeScale = 1; }

        if (isSlowmo == true)
        { Time.timeScale = slowmo; }

        print(isSlowmo);

    }


    void OnTriggerStay(Collider c_collider)
    {

        if (c_collider.gameObject == car)
        {
            isSlowmo = true;
        }
        else
        { isSlowmo = false; }
        
       
    }
    //void OnTriggreExit(Collider c_collider)
    //{
    //    if (c_collider.gameObject == car)
    //    {
    //        isSlowmo = false;
    //    }
    //}
}
