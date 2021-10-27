using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Score : MonoBehaviour
{
    public Player_Move[] playerScript;
    public Text[] playerUI;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerUI.Length; i++)
        {
            playerUI[i].color = playerScript[i].myColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i= 0; i < playerUI.Length; i++)
        {
            playerUI[i].text = "" +  playerScript[i].myScoreValue;
        }
    }
}
