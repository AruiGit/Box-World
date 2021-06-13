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

    //stats
    public int speed=2;
    public int enemyMovement;
    public int enemyAttacks=0;
    public int healthPoints = 5;

    //items
    [SerializeField] GameObject heartPickUpPrefab;
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        player = GameObject.Find("Player");
        enemyMovement = speed;
        if (transform.position == player.transform.position)
        {
            Destroy(this.gameObject);
        }
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
        if (enemyAttacks != 0)
        {
            Attack();
        }
        if (healthPoints <= 0)
        {
            DropItems();
            Destroy(this.gameObject);
        }
    }

    void UpdateRoad()
    {
        road = transform.position - player.transform.position;
    }

    void Attack()
    {
        player.GetComponent<Player>().TakeDamage(enemyAttacks);
        enemyAttacks = 0;
    }

    void Movement()
    {
        if ((int)road.x == 0 && (int)road.y == 1 || (int)road.y == 0 && (int)road.x == 1 || (int)road.x==0 && (int)road.y==-1 || (int)road.x==-1 && (int)road.y==0)
        {
            enemyAttacks = enemyMovement;
            enemyMovement = 0;
            Debug.Log("pierwszy if");
        }
        else if (road.x > 0)
        {
            transform.Translate(new Vector2(-1,0));
            enemyMovement--;
            Debug.Log("x>0");
        }
        else if (road.x < 0)
        {
            transform.Translate(new Vector2(1, 0));
            enemyMovement--;
            Debug.Log("x<0");
        }
        else if (road.y < 0)
        {
            transform.Translate(new Vector2(0, 1));
            enemyMovement--;
            Debug.Log("y<0");
        }
        else if (road.y > 0)
        {
            transform.Translate(new Vector2(0, -1));
            enemyMovement--;
            Debug.Log("y>0");
        }
        

        
    }


    IEnumerator MovementSpeed()
    {
        
        yield return new WaitForSeconds(1);
        Movement();
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
    public int GetHealth()
    {
        return healthPoints;
    }

    public int GetAttack()
    {
        return enemyAttacks;
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
        healthPoints += toMerge.GetHealth();
        enemyAttacks += toMerge.GetAttack();
        Destroy(toMerge.gameObject);
        
    }

    public void FinishedMoving()
    {
        finishedMoving = false;
    }

    public void TakeDamage(int value)
    {
        healthPoints = healthPoints - value;
    }

    void DropItems()
    {
        int dropID = Random.Range(0, 100);
        if (dropID > 99)
        {
            //drop item
        }
        else if (dropID > 10)
        {
            GameObject newHeart = Instantiate(heartPickUpPrefab, transform.position, Quaternion.identity);
        }
        else if (dropID > 75)
        {
            //drop money
        }
    }
}
