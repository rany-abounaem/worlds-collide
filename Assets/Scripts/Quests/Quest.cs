using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Possible quest states
public enum QuestState { READY, IN_PROGRESS, DONE }
//Possible responses after processing a quest
public enum QuestResponse { CLOSE_DIALOGUE, CONTINUE_DIALOGUE }

[System.Serializable]
public class Quest : ScriptableObject
{
    public int id, stage, numberOfStages; //numberOfStages: max number of stages
    public string questName, description;
    public QuestState state;
    //
    //public bool 
    public Dialogue[] dialogues; //All dialogues related to quest ordered by stage

    //Get the actual dialogue of a dialogue
    public string GetDialogueText()
    {
        return dialogues[stage].dialogue;
    }

    //Get the accept button's text of a dialogue
    public string GetAcceptText()
    {
        return dialogues[stage].accept;
    }

    //Get the reject button's text of a dialogue
    public string GetRejectText()
    {
        return dialogues[stage].reject;
    }

    //public bool IsAcceptEnabled()
    //{
    //    return dialogues[stage].acceptEnabled;
    //}

    //public bool IsRejectEnabled()
    //{
    //    return dialogues[stage].rejectEnabled;
    //}

    //Process the quest state and return the response
    public virtual QuestResponse ProcessQuest()
    {
        return QuestResponse.CLOSE_DIALOGUE;
    }
}
