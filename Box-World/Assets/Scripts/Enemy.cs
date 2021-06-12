using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Game_Manager gameManager;
    GameObject player;
    Vector2 road;
    bool canMove = true;
    bool isColliding = true;
    int collisionNumber = 0;
    bool isMarged = false;
    bool finishedMoving = false;
    [SerializeField]GameObject enemyPrefab;

    public int speed=2;
    public int enemyMovement;
    public int enemyAttacks=0;
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
        if (gameManager.GetTurn() == false && canMove==true && enemyMovement>0)
        {
            StartCoroutine(MovementSpeed());
            canMove = false;
        }
        if (gameManager.GetTurn() == true)
        {
            enemyMovement = speed;
        }
        if (collisionNumber <= 0)
        {
            isColliding = false;
        }
        if (isColliding==false)
        {
            Debug.Log("Destroing bc no collider");
            Destroy(this.gameObject);
        }
        if (enemyMovement <= 0 && enemyAttacks<=0&&finishedMoving==false)
        {
            gameManager.UpdateEnemiesTurn();
            finishedMoving = true;
        }
    }

    void UpdateRoad()
    {
        road = transform.position - player.transform.position;
    }

    void Movement()
    {
        if (road.x == 0 && road.y == 1 || road.y == 0 && road.x == 1 || road.x==0 && road.y==-1 || road.x==-1 && road.y==0)
        {
            enemyAttacks = enemyMovement;
            enemyMovement = 0;
            Debug.Log("Atakuje");
            enemyAttacks = 0;
            
            
        }
        else if (road.x > 0)
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
        

        
    }


    IEnumerator MovementSpeed()
    {
        Movement();
        yield return new WaitForSeconds(1);
        canMove = true;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionNumber++;
        if (collision.gameObject.CompareTag("Enemy") && isMarged == false)
        {
            Enemy scrip = collision.GetComponent<Enemy>();
            if (scrip.GetInstanceID() > GetInstanceID())
            {
                isMarged = false;
                collision.GetComponent<Enemy>().ChangeMarge();
                MergeEnemies(collision.GetComponent<Enemy>());
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        collisionNumber--;
        
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(int value)
    {
        speed = value;
    }
    public void ChangeMarge()
    {
        isMarged = false;
    }

    void MergeEnemies(Enemy toMerge)
    {
        Debug.Log("Destroing on merge: " + gameObject);
        speed = speed + toMerge.GetSpeed();
        Destroy(toMerge.gameObject);
        
    }

    public void FinishedMoving()
    {
        finishedMoving = false;
    }
}
