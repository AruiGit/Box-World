using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    [SerializeField]int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().PickUP(this);
            Destroy(this.gameObject);
        }
    }

    public int GetValue()
    {
        return value;
    }
}
