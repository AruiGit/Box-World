using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controler : MonoBehaviour
{

    public int xOffSet, yOffSet = 0;
    int playerMovement;

    Game_Manager gameManager;
    Player player;
    public GameObject attackPrefab;
    bool canEndTurn = false;

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
            Attack();
        }
    }

    void Movement()
    {
        
        RaycastHit2D ray;
       

        if (Input.GetKeyDown(KeyCode.D))
        {
            ray = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, LayerMask.GetMask("Enemy"));
            if (ray.collider == null)
            {
                gameObject.transform.Translate(Vector2.right);
            }
            
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
            ray = Physics2D.Raycast(transform.position, Vector2.left, 0.8f, LayerMask.GetMask("Enemy"));
            if (ray.collider == null)
            {
                gameObject.transform.Translate(Vector2.left);
            }
                
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
            ray = Physics2D.Raycast(transform.position, Vector2.up, 0.8f, LayerMask.GetMask("Enemy"));
            if (ray.collider == null)
            {
                gameObject.transform.Translate(Vector2.up);
            }
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
            ray = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Enemy"));
            if (ray.collider == null)
            {
                gameObject.transform.Translate(Vector2.down);
            }
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
        
        if (playerMovement <= 0 )
        {
                canEndTurn = false;
                gameManager.ChangeTurn();
        }
        transform.position = new Vector3((int)transform.position.x, (int)transform.position.y, -1);
        
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(attackPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z-1), Quaternion.identity);
            playerMovement--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiate(attackPrefab, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z-1), Quaternion.identity);
            playerMovement--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(attackPrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z-1), Quaternion.identity);
            playerMovement--;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiate(attackPrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z-1), Quaternion.identity);
            playerMovement--;
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
    public int GetPlayerMovesCounter()
    {
        return playerMovement;
    }
    public void ResetMovement()
    {
        playerMovement = player.GetSpeed();
    }
}
