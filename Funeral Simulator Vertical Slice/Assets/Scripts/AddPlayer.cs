using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayer : MonoBehaviour
{
    [SerializeField] GameObject contract;
    [SerializeField] GameObject leaderBoard;
    [SerializeField] GameObject playerNameGraph;
    int playerCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewPlayer()
    {
        if (playerNameGraph.GetComponent<Text>().text.Length > 0)
        { 
        int i = leaderBoard.GetComponent<LeaderBoardManager>().players.Capacity;
        leaderBoard.GetComponent<LeaderBoardManager>().players.Add(playerNameGraph.GetComponent<Text>().text);
            playerCounter++;
            PlayerPrefs.SetInt("PlayerIndex", playerCounter);
        PlayerPrefs.SetString("PlayerName" + playerCounter, playerNameGraph.GetComponent<Text>().text);
        }
    }

    public void SetContractActive()
    {
        if (playerNameGraph.GetComponent<Text>().text.Length > 0)
        { contract.SetActive(false); }
    }
}
