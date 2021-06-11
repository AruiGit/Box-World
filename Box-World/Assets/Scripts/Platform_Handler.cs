using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Handler : MonoBehaviour
{
    Character_Controler characterControler;
    int playerOffSetX, playerOffSetY;
    float playerPositionX, playerPositionY;

    public GameObject areaPrefab;
    public GameObject[] areasArrey;
    
    void Start()
    {
        characterControler = GameObject.Find("Player").GetComponent<Character_Controler>();
        areasArrey = GameObject.FindGameObjectsWithTag("Map_Area");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerPosition();
        areasArrey = GameObject.FindGameObjectsWithTag("Map_Area");

        if (playerOffSetX % 3 == 0 && playerOffSetX!=0 )
        {
            SpawnAreasHorizontal();
        }
        if (playerOffSetY != 0 && playerOffSetY % 3 == 0 )
        {
            SpawnAreasVertical();
        }
    }


    void CheckPlayerPosition()
    {
        playerOffSetX = characterControler.CheckPlayerOffSetX();
        playerOffSetY = characterControler.CheckPlayerOffSetY();
        playerPositionX = characterControler.CheckPlayerPositionX();
        playerPositionY = characterControler.CheckPlayerPositionY();
    }

    void SpawnAreasHorizontal()
    {
        foreach(GameObject area in areasArrey)
        {
            if (area.transform.position.x == playerPositionX - 1 - playerOffSetX*2)
            {
                float yPosition = area.transform.position.y;
                Destroy(area.gameObject);
                Instantiate(areaPrefab,new Vector3(playerPositionX + playerOffSetX-1, yPosition,0), Quaternion.identity);
            }
        }
        
    }



    void SpawnAreasVertical()
    {
        foreach(GameObject area in areasArrey)
        {
            if (area.transform.position.y== playerPositionY -1 - playerOffSetY * 2)
            {
                float xPosition = area.transform.position.x;
                Destroy(area.gameObject);
                Instantiate(areaPrefab, new Vector3(xPosition, playerPositionY+playerOffSetY-1, 0), Quaternion.identity);
            }

        }
    }

}
