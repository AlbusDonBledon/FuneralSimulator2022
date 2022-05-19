using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NewLevelSelect : MonoBehaviour {

    public GameObject[] Graves;
    public Camera MainCamera;    
    public Camera SelectCamera;
    public GameObject UISelect;
    public GameObject SecretUI;
    public int graveWidht;
    public int maxGraves;
    protected int chosen=0;
    public float[] XYZ;
    
   /*
    public int[] PostamentType;
    public int[] CrossGraveType;
    public int[] CommonGraveType;
    */
   // private int graveWidht = 4;
   // private int maxGraves = 11;

    // Use this for initialization
    void Start () {
        /*
         * cameraPosition = CameraRig.transform.position;
        print(cameraPosition.x);
        cameraRotation.rotation = CameraRig.transform.rotation;
        print(cameraRotation.rotation.x);  
        */
        MainCamera.gameObject.SetActive(false);
        SelectCamera.gameObject.SetActive(true);
        UISelect.SetActive(true);
       
    }
	
	// Update is called once per frame
	void Update () {
        // SelectCamera.transform.position = Vector3.MoveTowards(SelectCamera.transform.position, Graves[chosen].transform.position + new Vector3(0.2f, 1.3f, -2.85f), Time.deltaTime*3);
        if (Graves[chosen].tag == "CrossGrave")
        {
            print("CrossGrave");            
            SelectCamera.transform.position = Vector3.MoveTowards(SelectCamera.transform.position, Graves[chosen].transform.position + new Vector3(XYZ[0], XYZ[1], XYZ[2]), Time.deltaTime * 3);
        }
        if (Graves[chosen].tag == "CommonGrave")
        {
            print("CommonGrave");
            SelectCamera.transform.position = Vector3.MoveTowards(SelectCamera.transform.position, Graves[chosen].transform.position + new Vector3(XYZ[3], XYZ[4], XYZ[5]), Time.deltaTime * 3);
        }
        if (Graves[chosen].tag == "PostamentGrave")
        {
            print("Postament");
            SelectCamera.transform.position = Vector3.MoveTowards(SelectCamera.transform.position, Graves[chosen].transform.position + new Vector3(XYZ[6], XYZ[7], XYZ[8]), Time.deltaTime * 3);
        }
    }
    public void LeftGrave()
    {
        chosen--;
        if (chosen < 0) chosen++;
    }
    public void RightGrave()
    {
        chosen++;
        if (chosen > maxGraves) chosen--;
    }
    public void LowerGrave()
    {
       chosen = chosen - graveWidht;
        if (chosen < 0) chosen = chosen + graveWidht;
        print(chosen);
    }
    public void UpperGrave()
    {
        chosen = chosen + graveWidht;
        if (chosen > maxGraves) chosen = chosen - graveWidht;
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(chosen+1);
    }
    public void SelectFirstGrave(int Lvl)
    {

        //print("выбрал " + gameObject.name + " могилу");
        //chosen = Convert.ToInt32(gameObject.name);
        chosen = Lvl;
        SecretUI.SetActive(false);
        SelectCamera.gameObject.SetActive(true);
        // SelectCamera.transform.rotation = Quaternion.FromToRotation(MainCamera.gameObject.transform.rotation.eulerAngles, SelectCamera.gameObject.transform.rotation.eulerAngles);
        //SelectCamera.transform.rotation = Quaternion.FromToRotation(MainCamera.gameObject.transform.rotation.eulerAngles,new Vector3(48.549f, -59.058f, 2.926f));
        MainCamera.gameObject.SetActive(false);
        UISelect.gameObject.SetActive(true);


    }
    public void BackToMainCamera()
    {
        SecretUI.SetActive(true);
        SelectCamera.gameObject.SetActive(false);
        UISelect.gameObject.SetActive(false);
        MainCamera.gameObject.SetActive(true);
    }
}
