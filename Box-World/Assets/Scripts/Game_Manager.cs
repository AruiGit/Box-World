using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    bool isPlayerTurn = true;
    Character_Controler player;
    Player playerStats;
    int enemiesTurnCounter = 0;
    int turnPassed = 0;
    GameObject[] enemiesArrey;
    float maxPlayerHealth, currentPlayerHealth;

    //UI__________________
    public Sprite[] healthBar;
    public Image healthBarUI;
    public Text moves;
  
    

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Character_Controler>();
        enemiesArrey = GameObject.FindGameObjectsWithTag("Enemy");
        playerStats = GameObject.Find("Player").GetComponent<Player>();
        maxPlayerHealth = playerStats.GetHP();
        currentPlayerHealth = maxPlayerHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesArrey = GameObject.FindGameObjectsWithTag("Enemy");
        currentPlayerHealth = playerStats.GetHP();

        if (enemiesTurnCounter== enemiesArrey.Length && isPlayerTurn==false)
        {
            foreach(GameObject enemy in enemiesArrey)
            {
                enemy.GetComponent<Enemy>().FinishedMoving();
            }
            ChangeTurn();
            player.ResetMovement();
        }
        if (isPlayerTurn == true)
        {
            enemiesTurnCounter = 0;
        }
        UpdateUI();
        
    }

    public bool GetTurn()
    {
        return isPlayerTurn;
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        turnPassed++;
    }

    public void UpdateEnemiesTurn()
    {
        enemiesTurnCounter++;
    }

    void UpdateUI()
    {
        UpdateHealthBar();
        UpdateMoves();
    }

    void UpdateHealthBar()
    {
        if (currentPlayerHealth / maxPlayerHealth >= 1)
        {
            healthBarUI.sprite = healthBar[10];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.9)
        {
            healthBarUI.sprite = healthBar[9];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.8)
        {
            healthBarUI.sprite = healthBar[8];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.7)
        {
            healthBarUI.sprite = healthBar[7];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.6)
        {
            healthBarUI.sprite = healthBar[6];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.5)
        {
            healthBarUI.sprite = healthBar[5];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.4)
        {
            healthBarUI.sprite = healthBar[4];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.3)
        {
            healthBarUI.sprite = healthBar[3];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.2)
        {
            healthBarUI.sprite = healthBar[2];
        }
        else if (currentPlayerHealth / maxPlayerHealth >= 0.1)
        {
            healthBarUI.sprite = healthBar[1];
        }
        else if (currentPlayerHealth / maxPlayerHealth < 0.1)
        {
            healthBarUI.sprite = healthBar[0];
        }
    }
    void UpdateMoves()
    {
        moves.text = "Moves: " + player.GetPlayerMovesCounter();
    }
}
