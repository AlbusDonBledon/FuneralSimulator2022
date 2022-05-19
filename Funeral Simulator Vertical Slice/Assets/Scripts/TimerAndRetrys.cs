using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimerAndRetrys : MonoBehaviour
{
    [SerializeField]
    Text enterField;

    [SerializeField]
    Text leaders;

    [SerializeField]
    Text score; /*время в юй*/

    [SerializeField]
    Text tries; /*рестарты в юй*/

    int playerIndex; 

    public float numbertimer; /*сохраненный результат времени*/

   public int numberoftries; /*сохраненый результат попыток*/

   public int scenenum; //номер сцены

    

    

    // Start is called before the first frame update
    void Start()
    {
        playerIndex = PlayerPrefs.GetInt("PlayerIndex");

        leaders.text = PlayerPrefs.GetFloat("HightScore" + scenenum + playerIndex, numbertimer).ToString();
        enterField.text = PlayerPrefs.GetInt("TryHightScore" + scenenum + playerIndex).ToString();

        scenenum = SceneManager.GetActiveScene().buildIndex; //узнать номер сцены
        print("scene number is "+scenenum);
        print("best time " + PlayerPrefs.GetFloat("HightScore" + scenenum + playerIndex, numbertimer));

        numberoftries = PlayerPrefs.GetInt("TryHightScore" + scenenum + playerIndex) +1;

        //у каждой сцены свои результаты
        score.text = PlayerPrefs.GetFloat("HightScore"+ scenenum + playerIndex, 1000).ToString();
        tries.text = PlayerPrefs.GetInt("TryHightScore" + scenenum + playerIndex).ToString();
        print("retries " + PlayerPrefs.GetInt("TryHightScore" + scenenum + playerIndex));
    }

    // Update is called once per frame
    void Update()
    {
        Grave grave = GameObject.Find("GraveTrigger").GetComponent<Grave>();

        if (grave.isDelivered==false){ TimeCounter(); }
            
        RestartCounter();
        ResetScore();
        ResetTime();

        if (grave.isDelivered) { Score(); }

    }

  void Score()
    {
        /*сохраняет самый лучший результат по времени*/
        if (numbertimer < PlayerPrefs.GetFloat("HightScore" + scenenum + playerIndex, 1900))
        {
            PlayerPrefs.SetFloat("HightScore" + scenenum + playerIndex, numbertimer);
            PlayerPrefs.SetInt("TryHightScore" + scenenum + playerIndex, numberoftries);
            leaders.text = PlayerPrefs.GetFloat("HightScore" + scenenum + playerIndex, numbertimer).ToString();
            enterField.text = numberoftries.ToString();          
        }
        else
        {
            PlayerPrefs.SetInt("TryHightScore" + scenenum + playerIndex, numberoftries);
            leaders.text = PlayerPrefs.GetFloat("HightScore" + scenenum + playerIndex, numbertimer).ToString();
            enterField.text = numberoftries.ToString();
        }
    }

    void RestartCounter()
    {
        //считает рестарты на одной сцене
        if (Input.GetButtonDown("Restart"))
        {
            numberoftries = numberoftries++;
            tries.text= numberoftries.ToString();
            PlayerPrefs.SetInt("TryHightScore" + scenenum + playerIndex, numberoftries++);          
        }
    }

    void TimeCounter()
    {
        numbertimer = numbertimer + Time.deltaTime;
        score.text = numbertimer.ToString("f3");
    }

    void ResetTime()
    {
        if (Input.GetButton("K"))
        { PlayerPrefs.DeleteKey("HightScore" + scenenum + playerIndex);
          PlayerPrefs.DeleteKey("TryHightScore" + scenenum + playerIndex);
        }
    }

    void ResetScore()
    {
        if(Input.GetButton("L"))
        { PlayerPrefs.DeleteKey("TryHightScore" + scenenum); }
    }
}
