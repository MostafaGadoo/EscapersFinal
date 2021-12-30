using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileAnim7 : MonoBehaviour
{

    private Animator anim;
    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.GetContact(0).point.x < transform.position.x)
        {

            anim.Play("Base Layer.break_tile3", 0, 5f);
            Object.Destroy(gameObject, 0.4f);
        }
    }
}
