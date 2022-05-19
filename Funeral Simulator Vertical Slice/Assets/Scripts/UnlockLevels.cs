using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    protected string currentLevel;
    protected int worldIndex;
    protected int levelIndex;
    //check if the player hits the Goal object

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goal")
        {
            UnlockLevels();   //unlock next level funxtion 
        }
    }

    protected void UnlockLevels()
    {
        //set the playerprefs value of next level to 1 to unlock
      //  for (int i = 0; i < LockedLevel.worlds; i++)
      //  {
            for (int j = 1; j < LockedLevel.levels; j++)
            {
                if (currentLevel == "Lvl"+ j.ToString())
                {
                   // worldIndex = (i + 1);
                    levelIndex = (j + 1);
                    PlayerPrefs.SetInt("Lvl"+ levelIndex.ToString(), 1);
                }
            }
      //  }
        //load the World1 level 
      //  Application.LoadLevel("World1");
    }
}