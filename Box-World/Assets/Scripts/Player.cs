using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 2;
    [SerializeField]int maxHealthPoints = 20;
    public int healthPoints;
    public int damage = 3;
    int money = 0;
    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void TakeDamage(int value)
    {
        healthPoints = healthPoints - value;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetHP()
    {
        return healthPoints;
    }

    public void PickUP(PickUP pickUP)
    {
        if (pickUP.CompareTag("PickUpHeart"))
        {
            healthPoints += pickUP.GetValue();
            if (healthPoints > maxHealthPoints)
            {
                healthPoints = maxHealthPoints;
            }
        }

        else if (pickUP.CompareTag("PickUpMoney"))
        {
            money += pickUP.GetValue();
        }
    }
}
