using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public float hp = 3;
    public float moveSpeed = 7f;
    public float jumpSpeed = 7f;
    public bool grounded = true;
    public bool jumping = false;

    public List<GameObject> hearts;
    public GameObject gemText;

    public GameObject jump;
    public GameObject die;
    public GameObject hit;
    public GameObject pickUp;


    Animator animator;
    bool immune = false;
    int gems = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // first checks if the player is trying to jump
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            if (jumping == false)
            {
                animator.SetBool("Jumping", true);
                jump.GetComponent<AudioSource>().Play();
            }
            jumping = true;
        }
        else if (grounded == true)
        {
            animator.SetBool("Jumping", false);
            jumping = false;
        }

        // checks if the player is trying to move left/right
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        // flips sprite when moviing backwards/forwrads
        if(Input.GetAxis("Horizontal") != 0)
           GetComponent<SpriteRenderer>().flipX = Input.GetAxis("Horizontal") < 0;

    }

    public Vector3 getPos() { return transform.position; }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
            kill();
        else if (collision.tag == "Gem")
        {
            pickUp.GetComponent<AudioSource>().Play();
            gems++;
            gemText.GetComponent<Text>().text = "" + gems;
            Destroy(collision.gameObject);
        }
    }

    // runs whenever the player collides with an enemy
    public void hurt(int damage)
    {
        if (immune == false)
        {
            // runs the hurt animation then makes the player immune
            animator.SetBool("Hurt", true);
            animator.SetBool("Hurt", false);
            immune = true;
            Invoke("unimmune", 1f);

            // decreases hp and checks for player death
            hp -= damage;
            if (hp <= 0)
                kill();

            hit.GetComponent<AudioSource>().Play();
            Destroy(hearts[0]);
            hearts.RemoveAt(0);
        }
    }

    // used to disable invisiblity frames
    void unimmune()
    {
        immune = false;
        animator.SetBool("Hurt", false);
    }

    // disables player movement and allows audio and animations to finish before switching scenes
    void kill()
    {
        animator.SetBool("Dead", true);
        die.GetComponent<AudioSource>().Play();
        moveSpeed = 0;
        jumpSpeed = 0;
        Debug.Log("dead");
        Invoke("EndGame", 2f);
    }

    void EndGame()
    {
        SceneManager.LoadScene("Start");
    }
}
