using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    float attackTime = 0.5f;
    Player player;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        damage = player.GetDamage();
        StartCoroutine(DestroyInstance());
    }

    IEnumerator DestroyInstance()
    {
        yield return new WaitForSeconds(attackTime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
