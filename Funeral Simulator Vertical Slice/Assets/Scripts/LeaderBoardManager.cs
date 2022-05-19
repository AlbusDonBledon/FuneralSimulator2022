using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
   public List<string> players;

    string score;
    
    float rowHeight = 70f;
    string name;
    int fontSize = 100;
    int place;
    // Start is called before the first frame update
    void Start()
    {
        // players.Sort();

        // this.DontDestroyOnLoad();
        this.gameObject.SetActive(true);
        players.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        print("players in base " + PlayerPrefs.GetInt("PlayerIndex") + " players in list " + players.Capacity);
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 90;
        for (int i = 0; i < players.Capacity; players.Add(name))
        {
            score = PlayerPrefs.GetFloat("HightScore" + scoreCanvas.GetComponent<TimerAndRetrys>().scenenum + name, scoreCanvas.GetComponent<TimerAndRetrys>().numbertimer).ToString();
            name = PlayerPrefs.GetString("PlayerName" + players[i]);
            // ........................................................................................ //Add place
            GUI.Label(new Rect(100, i * rowHeight, 1500, rowHeight), name, myStyle ); // Add player name
            GUI.Label(new Rect(players[i].Length+500, i * rowHeight, 1500, rowHeight), score, myStyle);//Add time
            // ........................................................................................ //Add try
        }
    }


}
