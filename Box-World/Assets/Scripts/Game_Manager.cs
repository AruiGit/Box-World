using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    bool isPlayerTurn = true;
    Character_Controler player;
    int enemiesTurnCounter = 0;
    GameObject[] enemiesArrey;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Character_Controler>();
        enemiesArrey = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        enemiesArrey = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesTurnCounter== enemiesArrey.Length && isPlayerTurn==false)
        {
            foreach(GameObject enemy in enemiesArrey)
            {
                enemy.GetComponent<Enemy>().FinishedMoving();
            }
            ChangeTurn();
        }
        if (isPlayerTurn == true)
        {
            
            enemiesTurnCounter = 0;
        }
        
    }

    public bool GetTurn()
    {
        return isPlayerTurn;
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }

    public void UpdateEnemiesTurn()
    {
        enemiesTurnCounter++;
    }
}
