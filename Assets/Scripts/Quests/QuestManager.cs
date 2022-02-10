using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Quest quest;
    public GameObject npc, dialoguePanel;
    public TextMeshProUGUI dialogue, accept, reject;
    public bool lookTowardsPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateDialogue();
            dialoguePanel.SetActive(true);
            if (lookTowardsPlayer)
                npc.transform.localScale = new Vector2(-npc.transform.localScale.x, npc.transform.localScale.y);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
            if (lookTowardsPlayer)
                npc.transform.localScale = new Vector2(-npc.transform.localScale.x, npc.transform.localScale.y);
        }
    }

    public void UpdateDialogue()
    {
        dialogue.text = quest.GetDialogueText();
        if(accept)
            accept.text = quest.GetAcceptText();
        if(reject)
            reject.text = quest.GetRejectText();
    }

    public void OpenDialogue()
    {
        UpdateDialogue();
        dialoguePanel.SetActive(true);
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    

    public void ProcessQuest()
    {
        QuestResponse questResponse = quest.ProcessQuest();
        if (questResponse == QuestResponse.CLOSE_DIALOGUE)
        {
            CloseDialogue();
        }
        else if (questResponse == QuestResponse.CONTINUE_DIALOGUE)
        {
            UpdateDialogue();
        }

    }

    


    //public void IncrementProgress()
    //{
    //    DialoguePanels[currentDialogueProgress].SetActive(false);
    //    currentDialogueProgress++;
    //    DialoguePanels[currentDialogueProgress].SetActive(true);
    //}

    //public void IncrementProgressAndClose()
    //{
    //    DialoguePanels[currentDialogueProgress].SetActive(false);
    //    currentDialogueProgress++;
    //}

    //public void CloseDialogue()
    //{
    //    DialoguePanels[currentDialogueProgress].SetActive(false);
    //}

}
