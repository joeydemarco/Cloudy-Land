using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crankScript : MonoBehaviour
{
    public List<int> crankList;
    public bool touching = false;
    public bool house;

    puzzleScript ps;

    delegate void Doer();
    Doer success;

    void Start()
    {
        ps = gameObject.transform.parent.gameObject.GetComponent<puzzleScript>();
        success = ps.checkSuccess;
    }

    // Update is called once per frame
    void Update()
    {
        // if player enter the door to the house, enter end/win scene
        if (house == true && touching == true && Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("End");

        // if the crank is being touched by the player, activate the crank and check
        // for puzzle completion (all cranks being down)
        if (Input.GetButtonDown("Fire1") && touching == true)
        {
            foreach (int i in crankList)
            {
                ps.Press(i);
            }
            success?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touching = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touching = false;
    }
}