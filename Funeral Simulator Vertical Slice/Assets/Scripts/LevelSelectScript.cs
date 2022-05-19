using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public Button[] levelButtons;
    public Button[] lockedButtons;
    public int[] needPoints;
    private int bodyPoints;
    private int coffinPoints;
    private int carlessPoints;
    private int summPoints;
    public GameObject[] checkYes;
    public GameObject[] checkNo;
    private int j = 0;
    bool Unlock = false;
    void Start()
    {               
        for (int i = 0; i < levelButtons.Length + 1 ; i++)
        {
            if (PlayerPrefs.GetInt("pointsCoffin" + (i + 1).ToString()) == 1)
            {
                checkNo[j].gameObject.SetActive(false);
                j++;
            }
            else
            {
                checkYes[j].gameObject.SetActive(false);
                j++;
            }
       
            if (PlayerPrefs.GetInt("pointsBody" + (i + 1).ToString()) == 1)
            {
                checkNo[j].gameObject.SetActive(false);
                j++;
            }
            else
            {
                checkYes[j].gameObject.SetActive(false);
                j++;
            }
            if (PlayerPrefs.GetInt("pointsCarless" + (i + 1).ToString()) == 1)
            {
                checkNo[j].gameObject.SetActive(false);
                j++;
            }
            else
            {
                checkYes[j].gameObject.SetActive(false);
                j++;
            }

            print(i);
        }
            for (int i = 1; i < levelButtons.Length + 1; i++)
        {   
            coffinPoints += PlayerPrefs.GetInt("pointsCoffin" + i.ToString());
            bodyPoints += PlayerPrefs.GetInt("pointsBody" + i.ToString());
            carlessPoints += PlayerPrefs.GetInt("pointsCarless" + i.ToString());
        }
        summPoints = carlessPoints + bodyPoints + coffinPoints;
        print("asdadasdasdasdasd");
        print(summPoints);
        for (int i = 0; i < levelButtons.Length + 1; i++)
        {
            if (summPoints >= needPoints[i])
            {

                lockedButtons[i].gameObject.SetActive(false);
            }
            else levelButtons[i].gameObject.SetActive(false);
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
            print("Saves Delete");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
