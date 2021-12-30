using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : enemyController
{

    private controller Player;
    public int speedtowardPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position,speedtowardPlayer * Time.deltaTime);
    }

    //public void Flip()
    //{
    //    isFacingRight = !isFacingRight;
    //    transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    //}

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
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerState>().TakeDamage(damage);
            Flip();
        }
    }
}
