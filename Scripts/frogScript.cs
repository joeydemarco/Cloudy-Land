using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogScript : enemyScript
{
    public bool seesPlayer = false;
    public bool grounded = true;
    public float jumpSpeed;
    Vector3 playerPos;
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        playerPos = ps.getPos();
        if (Vector3.Distance(transform.position, playerPos) < 5f)
        {
            seesPlayer = true;
        }
        else if (Vector3.Distance(transform.position, playerPos) > 10f)
        {
            seesPlayer = false;
        }

        if (seesPlayer && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            if (playerPos.x > transform.position.x)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, jumpSpeed), ForceMode2D.Impulse);
            else
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, jumpSpeed), ForceMode2D.Impulse);
            GetComponent<Animator>().SetBool("Jumping", true);
        }

        if (grounded)
        {
            GetComponent<Animator>().SetBool("Jumping", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ps.hurt(damage);
        }
    }
}
