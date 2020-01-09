using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    GameObject Player;
    
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (gameObject.transform.parent.tag == "Player")
            {
                Player.GetComponent<playerScript>().grounded = true;
            }
            else
            {
                Player.GetComponent<frogScript>().grounded = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (gameObject.transform.parent.tag == "Player")
            {
                Player.GetComponent<playerScript>().grounded = false;
            }
            else
            {
                Player.GetComponent<frogScript>().grounded = false;
            }
        }
    }
}
