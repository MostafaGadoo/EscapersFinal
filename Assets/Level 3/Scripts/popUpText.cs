using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpText : MonoBehaviour
{
    public Level4Text DManager  ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            string[] dialogue = {
             "Welcome to level 4 (Baby monsters):",
             "In this level you are going to fcae 3 monsters each monster will be killed by 2 shoots.",
             "Spikes acts like traps they are going to make you strat from the begining but will not affect your health.",
             "Good luck!!", 
            };

            DManager.SetSentence(dialogue);
            DManager.StartCoroutine(DManager.TypeDialogue());            
        }
    }
}

        
            
                

        
