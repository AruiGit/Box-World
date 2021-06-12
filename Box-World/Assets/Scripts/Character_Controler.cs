using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controler : MonoBehaviour
{

    public int xOffSet, yOffSet = 0;
    int playerMovement;

    Game_Manager gameManager;
    Player player;
    
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        player = GetComponent<Player>();
        playerMovement = player.GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetTurn())
        {
            Movement();
        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right);
            playerMovement--;
            if (xOffSet == 3)
            {
                xOffSet = 1;
            }
            else if (xOffSet == -3)
            {
                xOffSet = 1;
            }
            else
            {
                xOffSet++;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.Translate(Vector2.left);
            playerMovement--;
            if (xOffSet == -3)
            {
                xOffSet = -1;
            }
            else if (xOffSet == 3)
            {
                xOffSet = -1;
            }
            else
            {
                xOffSet--;
            }

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.Translate(Vector2.up);
            playerMovement--;
            if (yOffSet == 3)
            {
                yOffSet = 1;
            }
            else if (yOffSet == -3)
            {
                yOffSet = 1;
            }
            else
            {
                yOffSet++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.Translate(Vector2.down);
            playerMovement--;
            if (yOffSet == -3)
            {
                yOffSet = -1;
            }
            else if (yOffSet == 3)
            {
                yOffSet = -1;
            }
            else
            {
                yOffSet--;
            }
        }
        
        if (playerMovement <= 0)
        {
            gameManager.ChangeTurn();
            playerMovement = player.GetSpeed();
        }
    }

    public int CheckPlayerOffSetX()
    {
        return xOffSet;
    }
    public int CheckPlayerOffSetY()
    {
        return yOffSet;
    }
    public float CheckPlayerPositionX()
    {
        return transform.position.x;
    }
    public float CheckPlayerPositionY()
    {
        return transform.position.y;
    }
}
