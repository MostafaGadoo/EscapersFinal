using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int health = 16;
    public int lives = 0;
    public int damage = 3;
    public Slider healthUI;
    private Animator anim;
    //public GameObject deathEffect;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        
    }
    void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity =
                new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        FindObjectOfType<PlayerState>().TakeDamage(damage);
    //    }
    //}
    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.tag == "Wall")
    //    {
    //        Flip();
    //    }
    //    else if (collider.tag == "Enemy")
    //    {
    //        Flip();
    //    }
    //    if (collider.tag == "Player")
    //    {
    //        FindObjectOfType<PlayerState>().TakeDamage(damage);
    //    }
    //}

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health == 0) {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject, 0.9f);
    }

    public void TakeDamage(int damage)
    {

        this.health = this.health - damage;
        if (this.health < 0)
            this.health = 0;
        if (this.lives > 0 && this.health == 0)
        {
            // FindObjectOfType<levelManager>().RespawnPlayer();
            this.health = 16;
            this.lives--;
        }
        else if (this.lives == 0 && this.health == 0)
        {
           // anim.Play("Base Layer.Dead", 0, 0.1f);
            Debug.Log("Winner");
            Destroy(this.gameObject, 0.7f);
        }
        Debug.Log("Big Boss Health: " + this.health.ToString());
        Debug.Log("Big Boss Lives: " + this.lives.ToString());
        healthUI.value = health;
    }
}
