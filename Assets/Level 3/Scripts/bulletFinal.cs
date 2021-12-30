using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFinal : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {

        enemyController enemy = hitInfo.GetComponent<enemyController>();
        //if (enemy != null) {
        //    enemy.takeDamage(20);
        //}
        if (hitInfo.tag == "Enemy1")
        {
            enemy.takeDamage(10);
            //Destroy(hitInfo.gameObject);
            Destroy(this.gameObject);
            Debug.Log(hitInfo.name);
        } else if (hitInfo.tag == "Wall") {
            Destroy(this.gameObject);
        }
    }
    
}
