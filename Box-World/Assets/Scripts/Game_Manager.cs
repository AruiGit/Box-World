using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    bool isPlayerTurn = true;
    Character_Controler player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Character_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetTurn()
    {
        return isPlayerTurn;
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }
}
