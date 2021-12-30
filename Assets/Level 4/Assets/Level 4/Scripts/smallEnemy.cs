using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 1;
    void Start()
    {
        
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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
        else if (collider.tag == "Enemy")
        {
            Flip();
        }
        else if (collider.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        else if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerState>().TakeDamage(damage);
        }

    }
 

}
