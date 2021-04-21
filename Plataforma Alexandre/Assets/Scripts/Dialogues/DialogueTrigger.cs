using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void triggerDialogue()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
        FindObjectOfType<DialogueManager>().talking = true;
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("e"))
        {
            triggerDialogue();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            triggerDialogue();
        }
    }
}
