using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossumScript : enemyScript
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWall")
        {
            moveSpeed = -moveSpeed;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
        else if (collision.tag == "Player")
        {
            Debug.Log("possum damages player for " + damage + " hp");
            ps.hurt(damage);
        }
    }
}
