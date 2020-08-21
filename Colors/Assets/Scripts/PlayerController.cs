using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 5;
    public float speed = 70f;
    public float jumpPower = 350f;


    public bool grounded;
    public bool canDoubleJump;
    public bool greenupgrade = false;
    public bool redupgrade = false;
    public bool immune = true;
    public bool pressedz = true;

    public int curHealth;
    public int maxHealth = 3;

    public Transform playerSpawnPoint = null;
    private Rigidbody2D rb2d;
    private Animator anim;
    public GameObject HUDGreenPowerup;
    public GameObject GPText;
    public GameObject HUDRedPowerup;
    public GameObject RPText;
    public gameMaster gm;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        curHealth = maxHealth;
        HUDGreenPowerup.SetActive(false);
        GPText.SetActive(false);
        HUDRedPowerup.SetActive(false);
        RPText.SetActive(false);
      
    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("canDoubleJump", canDoubleJump);
        anim.SetBool("GreenUpgrade", greenupgrade);
        anim.SetBool("RedUpgrade", redupgrade);

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump && greenupgrade)
                {
                    SoundManager.PlaySound("doublejump");
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(0.8f * (Vector2.up * jumpPower));
                }
            }
        }
       

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Die();
        }

    }
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.x *= 0.75f;
        easeVelocity.z = 0.0f;

        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        float h = Input.GetAxis("Horizontal");
        //Ruszanie postacią
        rb2d.AddForce((Vector2.right * speed) * h);

        //Limit szybkości
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        if (Input.GetButtonDown("Hot") && redupgrade)
        {
        }

    }
    void Damage()
    {
        if (immune)
        {
            SoundManager.PlaySound("damage");
            immune = false;
            curHealth = curHealth - 1;
            Debug.Log(curHealth);
            Czekaj(2);
            immune = true;
        }
        
    }
    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GreenUpgrade"))
        {
            Destroy(collision.gameObject);
            greenupgrade = true;
            HUDGreenPowerup.SetActive(true);
            GPText.SetActive(true);
            yield return new WaitForSeconds(5);
            GPText.SetActive(false);
        }
        if (collision.CompareTag("RedUpgrade"))
        {
            Destroy(collision.gameObject);
            redupgrade = true;
            HUDRedPowerup.SetActive(true);
            RPText.SetActive(true);
            yield return new WaitForSeconds(5);
            RPText.SetActive(false);
        }
        if (collision.CompareTag("Teleport"))
        {
            playerSpawnPoint.transform.position = new Vector3(155, -5, 0);
        }
        if (collision.CompareTag("Teleport2"))
        {
            playerSpawnPoint.transform.position = new Vector3(311, -19, 0);
        }
        if (collision.CompareTag("KoniecGry"))
        {
            if (gm.points >= 10)
            {
                SceneManager.LoadScene(2);
            }
            if (gm.points < 10)
            {
                SceneManager.LoadScene(3);
            }
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gm.points += 1;

        }
        if (collision.CompareTag("Spadek"))
        {
             transform.position = playerSpawnPoint.position;
                Damage();
        }
      

    }
    public IEnumerator Czekaj(int liczbasekund)
    {
        yield return new WaitForSeconds(liczbasekund);
    }
}


