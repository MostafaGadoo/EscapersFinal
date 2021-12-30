using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogeLevel4 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] dialogueSentences;
    private int index = 0;
    public float typingspeed;
    public GameObject continueButton;
    public GameObject dialogueBox;
    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }
    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        foreach (char letter in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);

            if (textDisplay.text == dialogueSentences[index])
            {

                continueButton.SetActive(true);

            }
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }
    public void SetSentences(string[] sentences)
    {

        this.dialogueSentences = sentences;

    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < dialogueSentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentences = null;
            index = 0;
            player.constraints = RigidbodyConstraints2D.None;
            player.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}