using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controler : MonoBehaviour
{

    public int xOffSet, yOffSet = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Debug.Log(xOffSet % 3);
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Translate(Vector2.right);
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
            yOffSet++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.Translate(Vector2.down);
            yOffSet--;
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
