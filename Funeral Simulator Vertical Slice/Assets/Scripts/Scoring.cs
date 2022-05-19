using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    float scoreCounter;
    float speedMultyplyer;
    string multyplyer;
 

    [SerializeField]
    Text ScoreUI;
    [SerializeField]
    Text ScoreEndScore;

    [SerializeField]
    GameObject trueCar;
    SimpleCarController m_SimpleCarController;
    Drifting m_Drifting;
    FlipDetector m_Flipdetecror;
    OnCollisionEffects m_OnCollisionEffects;


    // Use this for initialization
    void Start ()
    {
        m_SimpleCarController = trueCar.GetComponent<SimpleCarController>();
        m_Drifting = trueCar.GetComponent<Drifting>();
        m_Flipdetecror =trueCar.GetComponent<FlipDetector>();
        m_OnCollisionEffects = trueCar.GetComponent<OnCollisionEffects>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateScore();
      UpdateEndScore();
 
    }

    private void UpdateScore()
    {
        if (m_SimpleCarController.currentSpeed > 15 && !m_Flipdetecror.flipped)
        {
            speedMultyplyer = (m_SimpleCarController.currentSpeed / 10);
            scoreCounter = scoreCounter + speedMultyplyer;
            multyplyer = "";          

           if (m_Drifting.isDrifting)
            {
                scoreCounter = scoreCounter + speedMultyplyer;
                multyplyer = " X2";                
            }                                         
        }            
        ScoreUI.text = (scoreCounter.ToString("F0") + multyplyer);
    }
    
    private void UpdateEndScore()
    { if (m_Flipdetecror.flipped){ScoreEndScore.text = ScoreUI.text; } }
}
