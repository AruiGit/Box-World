using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Controller : MonoBehaviour
{
    int spawnID;
    [SerializeField]GameObject enemyPrefab;
    void Start()
    {
        spawnID = Random.Range(0, 100);

        if (spawnID < 10)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(transform.position.x,transform.position.y,-1), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
