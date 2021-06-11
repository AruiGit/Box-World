using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Game_Manager gameManager;
    GameObject player;
    Vector2 road;

    public int speed=2;
    int enemyMovement;
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        player = GameObject.Find("Player");
        enemyMovement = speed;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRoad();
        if (gameManager.GetTurn() == false)
        {
            Movement();
        }
        
    }

    void UpdateRoad()
    {
        road = transform.position - player.transform.position;
    }

    void Movement()
    {
        if (road.x > 0)
        {
            transform.Translate(new Vector2(-1,0));
            enemyMovement--;
        }
        else if (road.x < 0)
        {
            transform.Translate(new Vector2(1, 0));
            enemyMovement--;
        }
        else if (road.y < 0)
        {
            transform.Translate(new Vector2(0, 1));
            enemyMovement--;
        }
        else if (road.y > 0)
        {
            transform.Translate(new Vector2(0, -1));
            enemyMovement--;
        }

        if (enemyMovement <= 0)
        {
            gameManager.ChangeTurn();
            enemyMovement = speed;
        }
    }
}
